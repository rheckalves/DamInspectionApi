using System.ComponentModel.DataAnnotations;

namespace DamInspectionApi.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(200)]
        public string Observations { get; set; } = string.Empty;

        [Required]
        public int RiskLevel { get; set; } // 1: Baixo, 2: Médio, 3: Alto

        public int DamId { get; set; }
        public Dam Dam { get; set; } // Associação com a Barragem
    }
}
