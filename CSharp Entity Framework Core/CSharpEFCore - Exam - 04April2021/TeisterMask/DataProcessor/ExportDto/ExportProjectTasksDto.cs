using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Task")]
    public class ExportProjectTasksDto
    {
        [XmlElement("Name")]
        public string TaskName { get; set; }

        [XmlElement("Label")]
        public string TaskLabel { get; set; }
    }
}
