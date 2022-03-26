using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.ExportDtos;
using ProductShop.ImportDtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersJson = File.ReadAllText("../../../Datasets/users.json");
            //ImportUsers(context, usersJson);

            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //ImportProducts(context, productsJson);

            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //ImportCategories(context, categoriesJson);

            //string categoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, categoryProductsJson);
            //Console.WriteLine(result);

            //string result = GetProductsInRange(context);

            //string result = GetSoldProducts(context);

            //string result = GetCategoriesByProductsCount(context);

            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            ICollection<ImportUserDto> dtoUsers = JsonConvert.DeserializeObject<ICollection<ImportUserDto>>(inputJson);

            ICollection<User> users = mapper.Map<ICollection<User>>(dtoUsers);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}"; 
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            ICollection<ImportProductDto> dtoProducts = JsonConvert.DeserializeObject<ICollection<ImportProductDto>>(inputJson);

            ICollection<Product> products = mapper.Map<ICollection<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}"; 
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            ICollection<ImportCategoryDto> dtoCategories = JsonConvert
                .DeserializeObject<ICollection<ImportCategoryDto>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            ICollection<Category> categories = mapper.Map<ICollection<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context,string inputJson)
        {
            InitializeAutoMapper();

            ICollection<ImportCategoryProductDto> dtoCategoryProducts = JsonConvert.DeserializeObject<ICollection<ImportCategoryProductDto>>(inputJson);

            ICollection<CategoryProduct> categoryProducts = mapper.Map<ICollection<CategoryProduct>>(dtoCategoryProducts);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}"; 
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            List<ExportProductDto> products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            JsonSerializerSettings jsonSettings = MyJsonSettings();

            string productsAsJson = JsonConvert.SerializeObject(products, jsonSettings);

            return productsAsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            List<ExportUserSoldProductsDto> users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new ExportUserSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(p => new ExportSoldProductDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            JsonSerializerSettings jsonSettings = MyJsonSettings();

            string usersAsJson = JsonConvert.SerializeObject(users, jsonSettings);

            return usersAsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            List<ExportCategoryProductsDto> categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(c => new ExportCategoryProductsDto
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):F2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):F2}"
                })
                .ToList();

            JsonSerializerSettings jsonSettings = MyJsonSettings();

            string categoriesAsJson = JsonConvert.SerializeObject(categories, jsonSettings);

            return categoriesAsJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .Select(x => new ExportUserProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ExportProductsDto
                    {
                        Count = x.ProductsSold
                        .Count(x => x.BuyerId != null),

                        Products = x.ProductsSold
                        .Where(x => x.BuyerId != null)
                        .Select(x => new ExportProductDto
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();

            ExportUsersWithSoldProductsDto resultUsers = new ExportUsersWithSoldProductsDto
            {
                UsersCount = users.Count,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            };

            string resultUsersAsJson = JsonConvert.SerializeObject(resultUsers, jsonSettings);

            return resultUsersAsJson;
        }

        private static JsonSerializerSettings MyJsonSettings()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            return jsonSettings;
        }

        private static void InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}