using System;

namespace CarDealer.DTO.ImportDtos
{
    public class ImportCustomerDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
