﻿using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class ExportBookDto
    {
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        [XmlElement("Name")]
        public string BookName { get; set; }

        [XmlElement("Date")]
        public string PublishedOn { get; set; }
    }
}
