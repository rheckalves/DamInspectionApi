using System.ComponentModel.DataAnnotations;

namespace DamInspectionApi.Models
{
    public class Dam
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;

        public List<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
