using System;

namespace CarDealer.DTO.ExportDtos
{
    public class ExportCustomerDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
