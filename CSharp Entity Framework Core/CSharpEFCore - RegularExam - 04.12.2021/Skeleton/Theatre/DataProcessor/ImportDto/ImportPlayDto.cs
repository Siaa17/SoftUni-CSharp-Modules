using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }
}
