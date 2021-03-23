using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        private static string DatasetsDirectoryPath = "../../../Datasets";
        private static string ResultsDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //ResetDatabase(db);
            //InitializeMapper();

            //01.Import Users
            //string inputUsersJson = File.ReadAllText($"{DatasetsDirectoryPath}/users.json");
            //Console.WriteLine(ImportUsers(db, inputUsersJson));

            //02. Import Products
            //string inputProductsJson = File.ReadAllText($"{DatasetsDirectoryPath}/products.json");
            //Console.WriteLine(ImportProducts(db, inputProductsJson));

            //03. Import Categories
            //string inputCategoriesJson = File.ReadAllText($"{DatasetsDirectoryPath}/categories.json");
            //Console.WriteLine(ImportCategories(db, inputCategoriesJson));

            //04. Import Categories and Products
            //string inputCategoriesProductsJson = File.ReadAllText($"{DatasetsDirectoryPath}/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(db, inputCategoriesProductsJson));

            //05. Export Products In Range
            //string json = GetProductsInRange(db);
            //File.WriteAllText($"{ResultsDirectoryPath}/products-in-range.json", json);

            //06. Export Sold Products
            string json = GetSoldProducts(db);
            File.WriteAllText($"{ResultsDirectoryPath}/users-sold-products.json", json);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            //InitializeMapper();

            var usersDto = JsonConvert.DeserializeObject<List<UserInputModelDto>>(inputJson);

            var users = mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            // InitializeMapper();

            var productsDto = JsonConvert.DeserializeObject<List<ProductInputModelDto>>(inputJson);

            var products = mapper.Map<List<Product>>(productsDto);

            context.Products.AddRange(products);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            //InitializeMapper();

            var categoriesDto = JsonConvert.DeserializeObject<List<CategoryInputModelDto>>(inputJson)
                                        .Where(x => x.Name != null)
                                        .ToList();

            var categories = mapper.Map<List<Category>>(categoriesDto);

            context.Categories.AddRange(categories);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            //InitializeMapper();

            var categoriesProductsDto = JsonConvert.DeserializeObject<List<CategoryProductInputModelDto>>(inputJson);

            var categoriesProducts = mapper.Map<List<CategoryProduct>>(categoriesProductsDto);
            context.CategoryProducts.AddRange(categoriesProducts);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeMapper();

            //var productsInRange = context.Products
            //                        .Where(p => p.Price >= 500 && p.Price <= 1000)
            //                        .ProjectTo<List<ProductsInRangeDto>>()
            //                        .ToList();

            var productsInRange = context.Products
                                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price,
                                        seller = p.Seller.FirstName + " " + p.Seller.LastName
                                    })
                                    .OrderBy(p => p.price)
                                    .ToList();

            var json = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                                .Where(u => u.ProductsSold.Count > 0)
                                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                                .OrderBy(u => u.LastName)
                                .ThenBy(u => u.FirstName)
                                .Select(u => new
                                {
                                    firstName = u.FirstName,
                                    lastName = u.LastName,
                                    soldProducts = u.ProductsSold.Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price,
                                        buyerFirstName = p.Buyer.FirstName,
                                        buyerLastName = p.Buyer.LastName
                                    })
                                })
                                .ToList();

            var json = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented);

            return json;
        }

        public static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }
    }
}