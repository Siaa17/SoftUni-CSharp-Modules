using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportProjectTasksDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string TaskName { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string TaskOpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string TaskDueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(0, 4)]
        public int LabelType { get; set; }
    }
}
