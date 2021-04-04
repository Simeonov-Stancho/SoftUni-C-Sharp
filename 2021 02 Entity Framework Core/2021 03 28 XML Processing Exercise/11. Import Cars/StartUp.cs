using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static string DatasetsPath = "../../../Datasets";
        private static string ResultDatasetsPath = "../../../Datasets/Results";

        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //InitializeMapper()

            //09. Import Suppliers
            //string inputSuppliersXml =File.ReadAllText( $"{DatasetsPath}/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(db, inputSuppliersXml));

            //10. Import Parts
            //string inputPartsXml = File.ReadAllText($"{DatasetsPath}/parts.xml");
            //Console.WriteLine(ImportParts(db, inputPartsXml));

            //11. Import Cars
            string inputCarXml = File.ReadAllText($"{DatasetsPath}/cars.xml");
            Console.WriteLine(ImportCars(db, inputCarXml));

            //12. Import Customers

            //13. Import Sales

            //14. Export Cars With Distance

            //15. Export Cars From Make BMW

            //16. Export Local Suppliers

            //17. Export Cars With Their List Of Parts

            //18. Export Total Sales By Customer

            //19. Export Sales With Applied Discount

            //CleanAndCreateDb(db, inputSuppliersXml);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var xmlRoot = new XmlRootAttribute("Suppliers");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSupplierDto>), xmlRoot);

            var suppliersDto = (List<ImportSupplierDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var xmlRoot = new XmlRootAttribute("Parts");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportPartDto>), xmlRoot);

            var partsDto = (List<ImportPartDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliersId = context.Suppliers.Select(s => s.Id).ToList();
            var parts = mapper.Map<List<Part>>(partsDto)
                .Where(p => suppliersId.Contains(p.SupplierId));

            context.Parts.AddRange(parts);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Cars");

            var xmlSerializer = new XmlSerializer(typeof(List<ImportCarDto>), xmlRoot);

            var carsDto = (List<ImportCarDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var currentCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var partsDto = carDto.Parts.Where(p => context.Parts.Any(x => x.Id == p.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var partDto in partsDto)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partDto,
                        Car = currentCar
                    };

                    partCars.Add(partCar);
                }

                cars.Add(currentCar);
            }

            context.PartCars.AddRange(partCars);
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        private static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }

        public static void ResetDatabese(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void CleanAndCreateDb(CarDealerContext context, string suppliersXml, string partsXml, string carXml)
        {
            ResetDatabese(context);
            ImportSuppliers(context, suppliersXml);
            ImportParts(context, partsXml);
            ImportCars(context, carXml);
        }
    }
}