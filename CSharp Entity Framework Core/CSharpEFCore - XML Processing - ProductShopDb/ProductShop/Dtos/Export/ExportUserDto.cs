﻿using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ExportUserSoldProductsDto[] SoldProducts { get; set; }
    }
}
