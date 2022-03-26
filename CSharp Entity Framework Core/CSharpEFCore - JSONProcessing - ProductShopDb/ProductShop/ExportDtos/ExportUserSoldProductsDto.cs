using System.Collections.Generic;

namespace ProductShop.ExportDtos
{
    public class ExportUserSoldProductsDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ExportSoldProductDto> SoldProducts { get; set; }
    }
}
