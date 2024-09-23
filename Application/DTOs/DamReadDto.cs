namespace DamInspectionApi.Application.DTOs
{
    public class DamReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<InspectionSummaryDto>? Inspections { get; set; }
    }
}
