namespace DamInspectionApi.Application.DTOs
{
    public class InspectionReadDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public int RiskLevel { get; set; }
        public DamSummaryDto? Dam { get; set; }
    }

    public class DamSummaryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
