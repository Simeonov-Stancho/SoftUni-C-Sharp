using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        private static string DatasetsDirectoryPath = "../../../Datasets";
        private static string ResultDirectoryPath = "../../../Datasets/Results/";

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //ResetDatabase(db);
            //InitializeMapper();

            //09.Import Suppliers
            //string inputJasonSupplier = File.ReadAllText($"{DatasetsDirectoryPath}/suppliers.json");
            // Console.WriteLine(ImportSuppliers(db, inputJasonSupplier));

            //10. Import Parts
            string inputJsonParts = File.ReadAllText($"{DatasetsDirectoryPath}/parts.json");
            Console.WriteLine(ImportParts(db, inputJsonParts));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var suppliersDto = JsonConvert.DeserializeObject<List<SupplierInputModelDto>>(inputJson);

            var supplier = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(supplier);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliersId = context.Suppliers
                                    .Select(x => x.Id)
                                    .ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(s => suppliersId.Contains(s.SupplierId))
                .ToList();

            //var partsDto = JsonConvert
            //    .DeserializeObject<List<PartInputModelDto>>(inputJson)
            //    .Where(s=> suppliersId.Contains(s.SupplierId));
                        
            //var parts = mapper.Map<List<Part>>(partsDto);

            context.Parts.AddRange(parts);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }
    }
}