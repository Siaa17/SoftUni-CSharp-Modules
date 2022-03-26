using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDtos
{
    [XmlType("car")]
    public class ExportCarMakeBmwDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}
