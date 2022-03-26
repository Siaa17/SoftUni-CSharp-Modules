using System.Collections.Generic;

namespace ProductShop.ExportDtos
{
    public class ExportProductsDto
    {
        public int Count { get; set; }

        public ICollection<ExportProductDto> Products { get; set; }
    }
}
