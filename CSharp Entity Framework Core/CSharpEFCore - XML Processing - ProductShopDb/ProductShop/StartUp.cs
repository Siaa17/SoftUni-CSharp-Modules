using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Dtos.Import;
using System.Text;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string userXml = File.ReadAllText("Datasets/users.xml");
            //ImportUsers(context, userXml);

            //string productXml = File.ReadAllText("Datasets/products.xml");
            //ImportProducts(context, productXml);

            //string categoryXml = File.ReadAllText("Datasets/categories.xml");
            //ImportCategories(context, categoryXml);

            //string categoryProductXml = File.ReadAllText("Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, categoryProductXml);
            //Console.WriteLine(result);

            //string result = GetProductsInRange(context);

            //string result = GetSoldProducts(context);

            //string result = GetCategoriesByProductsCount(context);

            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Users");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportUserDto[] dtoUsers = (ImportUserDto[])xmlSerializer.Deserialize(reader);

            User[] users = dtoUsers
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Products");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportProductDto[] dtoProducts = (ImportProductDto[])xmlSerializer.Deserialize(reader);

            Product[] products = dtoProducts
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x.BuyerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("Categories");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportCategoryDto[] dtoCategories = (ImportCategoryDto[])xmlSerializer.Deserialize(reader);

            Category[] categories = dtoCategories
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xlmRoot = new XmlRootAttribute("CategoryProducts");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProducts[]), xlmRoot);

            StringReader reader = new StringReader(inputXml);

            ImportCategoryProducts[] dtoCategoryProducts = (ImportCategoryProducts[])xmlSerializer.Deserialize(reader);

            CategoryProduct[] categoryProducts = dtoCategoryProducts
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                })
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRange[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportProductInRange[] productsInRangeDto = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductInRange
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(writer, productsInRangeDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportUserDto[] userSoldProductsDto = context.Users
                .Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Where(x => x.Buyer != null)
                    .Select(x => new ExportUserSoldProductsDto
                    {
                        Name = x.Name,
                        Price = x.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            xmlSerializer.Serialize(writer, userSoldProductsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportCategoryDto[] categoriesByProductsCountDto = context.Categories
                .Select(x => new ExportCategoryDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            xmlSerializer.Serialize(writer, categoriesByProductsCountDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUsersRootDto), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportUsersRootDto usersWithProductsDto = new ExportUsersRootDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                Users = context.Users
                .ToArray()
                .Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new ExportUserWithProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ExportSoldProductsDto
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold
                        .Select(x => new ExportProductDto
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray()
            };
 
            xmlSerializer.Serialize(writer, usersWithProductsDto, namespaces); 

            return sb.ToString().TrimEnd();
        }
    }
}