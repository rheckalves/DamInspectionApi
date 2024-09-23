namespace DamInspectionApi.Application.DTOs
{
    public class InspectionSummaryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int RiskLevel { get; set; }
    }
}
