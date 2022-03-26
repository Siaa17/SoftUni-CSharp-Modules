using System.Collections.Generic;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmlpoyeeTasksDto
    {
        public string Username { get; set; }

        public ICollection<ExportTaskDto> Tasks { get; set; }
    }
}
