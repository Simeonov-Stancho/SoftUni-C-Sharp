using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static string DatasetsDirectoryPath = "../../../Datasets";
        private static string ResultDirectoryPath = "../../../Datasets/Results/";

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //InitializeMapper();

            //01. Import Users
            //var inputUsersXml = File.ReadAllText($"{DatasetsDirectoryPath}/users.xml");
            //Console.WriteLine(ImportUsers(db, inputUsersXml));

            //02. Import Products
            //var inputProductsXml = File.ReadAllText($"{DatasetsDirectoryPath}/products.xml");
            //Console.WriteLine(ImportProducts(db, inputProductsXml));

            //03. Import Categories
            //var inputCategoriesXml = File.ReadAllText($"{DatasetsDirectoryPath}/categories.xml");
            //Console.WriteLine(ImportCategories(db, inputCategoriesXml));

            //04. Import Categories and Products
            //var inputCategoriesProductsXml = File.ReadAllText($"{DatasetsDirectoryPath}/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(db, inputCategoriesProductsXml));

            //05. Export Products In Range
            string xmlProducts = GetProductsInRange(db);
            File.WriteAllText($"{ResultDirectoryPath}/products-in-range.xml", xmlProducts);

            //06. Export Sold Products

            //07. Export Categories By Products Count

            //08. Export Users and Products


            //CleanAndCreateDb(db, inputUsersXml, inputProductsXml, inputCategoriesXml);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //InitializeMapper();

            var xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(List<UserDto>), xmlRoot);

            var usersDto = (List<UserDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = Mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Products");
            var xmlSerializer = new XmlSerializer(typeof(List<ProductDto>), xmlRoot);

            var productsDto = (List<ProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> productsForJudge = new List<Product>();

            foreach (var product in productsDto)
            {
                Product productJudge = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    SellerId = product.SellerId,
                    BuyerId = product.BuyerId,
                };

                productsForJudge.Add(productJudge);
            }

            //var products = Mapper.Map<List<Product>>(productsDto);  not working in  judge

            context.Products.AddRange(productsForJudge);
            context.SaveChanges();

            return $"Successfully imported {productsForJudge.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            //InitializeMapper();

            var xmlRoot = new XmlRootAttribute("Categories");
            var xmlSerializer = new XmlSerializer(typeof(List<CategoryDto>), xmlRoot);

            var categoriesDto = (List<CategoryDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            //Not working in judge
            //var categories = Mapper.Map<List<Category>>(categoriesDto);
            //context.Categories.AddRange(categories);

            List<Category> categoriesForJudge = new List<Category>();

            foreach (var category in categoriesDto)
            {
                Category categoryForJudge = new Category()
                {
                    Name = category.Name
                };

                categoriesForJudge.Add(categoryForJudge);
            }

            context.Categories.AddRange(categoriesForJudge);

            context.SaveChanges();

            return $"Successfully imported {categoriesForJudge.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            //Working
            //InitializeMapper();
            //var xmlRoot = new XmlRootAttribute("CategoryProducts");
            //var xmlSerializer = new XmlSerializer(typeof(List<CategoryProductDto>), xmlRoot);

            //var catProdDto = (List<CategoryProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            //var categoriesProducts = Mapper.Map<List<CategoryProduct>>(catProdDto.Where(cp=>context.Categories.Any(c=>c.Id == cp.CategoryId)&& context.Products.Any(p=>p.Id == cp.ProductId)));

            //context.CategoryProducts.AddRange(categoriesProducts);
            //context.SaveChanges();

            //return $"Successfully imported {categoriesProducts.Count}";

            // for 100/100 in Judge
            //InitializeMapper();
            var xmlRoot = new XmlRootAttribute("CategoryProducts");
            var xmlSerializer = new XmlSerializer(typeof(List<CategoryProductDto>), xmlRoot);

            var catProdDto = (List<CategoryProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<CategoryProduct> categoriesProductsForJudge = new List<CategoryProduct>();

            foreach (var catprod in catProdDto)
            {
                CategoryProduct cpForJudge = new CategoryProduct()
                {
                    CategoryId = catprod.CategoryId,
                    ProductId = catprod.ProductId,
                };

                if (context.Categories.Any(c => c.Id == cpForJudge.CategoryId) && context.Products.Any(p => p.Id == cpForJudge.ProductId))
                {
                    categoriesProductsForJudge.Add(cpForJudge);
                }
            }

            context.CategoryProducts.AddRange(categoriesProductsForJudge);
            context.SaveChanges();

            return $"Successfully imported {categoriesProductsForJudge.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ProductInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                })
                .ToList();

            var xmlRoot = new XmlRootAttribute("Products");
            var xmlSerializer = new XmlSerializer(typeof(List<ProductInRangeDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);
           
            StringBuilder sb = new StringBuilder();
            xmlSerializer.Serialize(new StringWriter(sb), productInRange, namespaces);

            return sb.ToString().Trim();
        }

        public static void ResetDatabese(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<ProductShopProfile>(); });
        }

        public static void CleanAndCreateDb(ProductShopContext context, string inputUsersXml, string inputProductsXml, string inputCategoriesXml)
        {
            ResetDatabese(context);
            ImportUsers(context, inputUsersXml);
            ImportProducts(context, inputProductsXml);
            ImportCategories(context, inputCategoriesXml);
        }
    }
}