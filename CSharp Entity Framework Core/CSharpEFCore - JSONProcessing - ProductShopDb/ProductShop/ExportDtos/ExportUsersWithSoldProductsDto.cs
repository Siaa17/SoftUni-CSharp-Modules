using System.Collections.Generic;

namespace ProductShop.ExportDtos
{
    public class ExportUsersWithSoldProductsDto
    {
        public int UsersCount { get; set; }

        public ICollection<ExportUserProductsDto> Users { get; set; }
    }
}
