using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

            //01. Import Users
            var inputUsersXml = File.ReadAllText($"{DatasetsDirectoryPath}/users.xml");
            Console.WriteLine(ImportUsers(db, inputUsersXml));

            //02. Import Products

            //03. Import Categories

            //04. Import Categories and Products

            //05. Export Products In Range

            //06. Export Sold Products

            //07. Export Categories By Products Count

            //08. Export Users and Products
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            var xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportUserDto>), xmlRoot);

            var usersDto = (List<ImportUserDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = Mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
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

    }
}