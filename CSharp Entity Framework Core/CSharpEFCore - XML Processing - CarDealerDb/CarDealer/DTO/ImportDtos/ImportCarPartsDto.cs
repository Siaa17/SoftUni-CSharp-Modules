using System.Xml.Serialization;

namespace CarDealer.DTO.ImportDtos
{
    [XmlType("partId")]
    public class ImportCarPartsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
