using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.ResultsDto;
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
            // string inputJsonSales = File.ReadAllText($"{DatasetsDirectoryPath}/sales.json");
            // Console.WriteLine(ImportSales(db, inputJsonSales));

            // 14.Export Ordered Customers
            //string jsonCustomersData = GetOrderedCustomers(db);
            //File.WriteAllText($"{ResultDirectoryPath}/ordered-customers.json", jsonCustomersData);

            //15. Export Cars From Make Toyota
            string jsonCars = GetCarsFromMakeToyota(db);
            File.WriteAllText($"{ResultDirectoryPath}/toyota-cars.json", jsonCars);
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

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            //InitializeMapperExport();

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonCustomers;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            //InitializeMapperExport();

            //var carsToyota = context.Cars
            //    .Where(c => c.Make == "Toyota")
            //    .OrderBy(c => c.Model)
            //    .ThenByDescending(c => c.TravelledDistance)
            //    .ProjectTo<CarOutputModelDto>()
            //    .ToList();

            //var json = JsonConvert.SerializeObject(carsToyota, Formatting.Indented);

            //return json;

            var carsToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(carsToyota, Formatting.Indented);

            return json;
        }

        public static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public static void InitializeMapperExport()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
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