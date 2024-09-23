using DamInspectionApi.Models;

namespace DamInspectionApi.Services.Interfaces
{
    public interface IInspectionService
    {
        Task<IEnumerable<Inspection>> GetAllAsync();
        Task<Inspection?> GetByIdAsync(int id);
        Task<Inspection> CreateAsync(Inspection inspection);
        Task<bool> UpdateAsync(int id, Inspection inspection);
        Task<bool> DeleteAsync(int id);
        bool InspectionExists(int id);
    }
}
