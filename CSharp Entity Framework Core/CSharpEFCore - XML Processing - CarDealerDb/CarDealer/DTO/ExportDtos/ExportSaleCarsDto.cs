using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDtos
{
    [XmlType("car")]
    public class ExportSaleCarsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}
