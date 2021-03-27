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
            //Console.WriteLine(ImportSuppliers(db, inputJasonSupplier));

            //10. Import Parts
            //string inputJsonParts = File.ReadAllText($"{DatasetsDirectoryPath}/parts.json");
            //Console.WriteLine(ImportParts(db, inputJsonParts));

            //11. Import Cars
            //string inputJsonCars = File.ReadAllText($"{DatasetsDirectoryPath}/cars.json");
            //Console.WriteLine(ImportCars(db, inputJsonCars));

            //12. Import Customers
            //string inputJsonCustomer = File.ReadAllText($"{DatasetsDirectoryPath}/customers.json");
            //Console.WriteLine(ImportCustomers(db, inputJsonCustomer));

            //13. Import Sales
            string inputJsonSales = File.ReadAllText($"{DatasetsDirectoryPath}/sales.json");
            Console.WriteLine(ImportSales(db, inputJsonSales));

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
            InitializeMapper();

            var suppliersId = context.Suppliers
                                    .Select(x => x.Id)
                                    .ToList();

            var partsDto = JsonConvert
                .DeserializeObject<List<PartInputModelDto>>(inputJson)
                .Where(s => suppliersId.Contains(s.SupplierId));

            var parts = mapper.Map<List<Part>>(partsDto);

            context.Parts.AddRange(parts);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert
                .DeserializeObject<List<CarInputModelDto>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar()
                    {
                        PartId = partId
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var customersDto = JsonConvert.DeserializeObject<List<CustomerInputModelDto>>(inputJson);

            var customers = mapper.Map<List<Customer>>(customersDto);

            context.AddRange(customers);

            return $"Successfully imported {context.SaveChanges()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var salesDto = JsonConvert.DeserializeObject<List<SaleInputModelDto>>(inputJson);

            var sales = mapper.Map<List<Sale>>(salesDto);

            context.Sales.AddRange(sales);

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