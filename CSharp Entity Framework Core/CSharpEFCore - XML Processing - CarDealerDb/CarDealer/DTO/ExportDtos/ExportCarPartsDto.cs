using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDtos
{
    [XmlType("part")]
    public class ExportCarPartsDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
