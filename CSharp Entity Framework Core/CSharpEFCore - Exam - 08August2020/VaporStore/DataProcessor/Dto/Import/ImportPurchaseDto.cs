using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [Required]
        [XmlElement("Type")]
        public PurchaseType? Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        [XmlElement("Key")]
        public string ProductKey { get; set; }

        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        [XmlElement("Card")]
        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
