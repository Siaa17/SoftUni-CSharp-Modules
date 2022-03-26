using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.ExportDtos
{
    public class ExportSaleInformationDto
    {
        [JsonProperty("car")]
        public ExportOnlyCarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("Discount")]
        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}
