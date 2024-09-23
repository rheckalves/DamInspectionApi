using DamInspectionApi.Models;

namespace DamInspectionApi.Services.Interfaces
{
    public interface IDamService
    {
        Task<IEnumerable<Dam>> GetAllAsync();
        Task<Dam?> GetByIdAsync(int id);
        Task<Dam> CreateAsync(Dam dam);
        Task<bool> UpdateAsync(int id, Dam dam);
        Task<bool> DeleteAsync(int id);
        bool DamExists(int id);
    }
}
