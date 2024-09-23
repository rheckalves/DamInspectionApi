namespace DamInspectionApi.Application.DTOs
{
    public class InspectionWriteDto
    {
        public DateTime Date { get; set; }
        public string Observations { get; set; } = string.Empty;
        public int RiskLevel { get; set; }
        public int DamId { get; set; }
    }
}
