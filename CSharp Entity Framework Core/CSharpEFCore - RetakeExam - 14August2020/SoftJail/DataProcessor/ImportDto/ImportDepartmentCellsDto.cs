using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentCellsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        public string Name { get; set; }

        public ICollection<ImportCellDto> Cells { get; set; }
    }
}
