using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTO.ExportDtos;
using CarDealer.DTO.ImportDtos;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string supplierXml = File.ReadAllText("Datasets/suppliers.xml");
            //ImportSuppliers(context, supplierXml);

            //string partXml = File.ReadAllText("Datasets/parts.xml");
            //ImportParts(context, partXml);

            //string carXml = File.ReadAllText("Datasets/cars.xml");
            //ImportCars(context, carXml);

            //string customerXml = File.ReadAllText("Datasets/customers.xml");
            //ImportCustomers(context, customerXml);

            //string saleXml = File.ReadAllText("Datasets/sales.xml");
            //string result = ImportSales(context, saleXml);
            //Console.WriteLine(result);

            //string result = GetCarsWithDistance(context);

            //string result = GetCarsFromMakeBmw(context);

            //string result = GetLocalSuppliers(context);

            //string result = GetCarsWithTheirListOfParts(context);

            //string result = GetTotalSalesByCustomer(context);

            string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Suppliers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportSupplierDto[] dtoSupliers = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            Supplier[] suppliers = dtoSupliers
                .Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Parts");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportPartDto[] dtoParts = (ImportPartDto[])xmlSerializer.Deserialize(reader);

            Part[] parts = dtoParts
               .Where(s => context.Suppliers.Select(x => x.Id).Contains(s.SupplierId))
               .Select(x => new Part
               {
                   Name = x.Name,
                   Price = x.Price,
                   Quantity = x.Quantity,
                   SupplierId = x.SupplierId
               })
               .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Cars");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportCarDto[] dtoCars = (ImportCarDto[])xmlSerializer.Deserialize(reader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (ImportCarDto dtoCar in dtoCars)
            {
                Car car = new Car
                {
                    Make = dtoCar.Make,
                    Model = dtoCar.Model,
                    TravelledDistance = dtoCar.TraveledDistance
                };

                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();

                var parts = dtoCar.Parts.Select(p => p.Id).Distinct();

                foreach (int partId in parts)
                {
                    Part part = context.Parts.Find(partId);

                    if (part == null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar
                    {
                        Car = car,
                        Part = part
                    };

                    currentCarParts.Add(partCar);
                }

                car.PartCars = currentCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Customers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportCustomerDto[] dtoCustomers = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

            Customer[] customers = dtoCustomers
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Sales");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportSaleDto[] dtoSales = (ImportSaleDto[])xmlSerializer.Deserialize(reader);

            Sale[] sales = dtoSales
                .Where(x => context.Cars.Any(c => c.Id == x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportCarWithDistanceDto[] carsDto = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Select(x => new ExportCarWithDistanceDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString()
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(writer, carsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarMakeBmwDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportCarMakeBmwDto[] carsDto = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarMakeBmwDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(writer, carsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportLocalSuppliersDto[] suppliersDto = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            xmlSerializer.Serialize(writer, suppliersDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithListOfPartsDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportCarWithListOfPartsDto[] carsWithPartsDto = context.Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Select(x => new ExportCarWithListOfPartsDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString(),
                    Parts = x.PartCars
                    .Select(x => new ExportCarPartsDto
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price
                    })                   
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(writer, carsWithPartsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportTotalSalesByCustomerDto[] totalSalesByCustomerDto = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(c => new ExportTotalSalesByCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            xmlSerializer.Serialize(writer, totalSalesByCustomerDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleWithDiscountDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportSaleWithDiscountDto[] salesWithDiscountDto = context.Sales
                .Select(s => new ExportSaleWithDiscountDto
                {
                    Car = new ExportSaleCarsDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance.ToString()
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    //PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)
                }).ToArray();

            xmlSerializer.Serialize(writer, salesWithDiscountDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}