namespace ProductShop.ExportDtos
{
    public class ExportUserProductsDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ExportProductsDto SoldProducts { get; set; }
    }
}
