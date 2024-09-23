using DamInspectionApi.Models;
using DamInspectionApi.Repositories.Interfaces;
using DamInspectionApi.Services.Interfaces;

namespace DamInspectionApi.Services
{
    public class DamService : IDamService
    {
        private readonly IDamRepository _repository;

        public DamService(IDamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Dam>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Dam?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Dam> CreateAsync(Dam dam)
        {
            await _repository.AddAsync(dam);
            await _repository.SaveChangesAsync();
            return dam;
        }

        public async Task<bool> UpdateAsync(int id, Dam dam)
        {
            if (id != dam.Id)
            {
                return false;
            }

            _repository.Update(dam);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dam = await _repository.GetByIdAsync(id);
            if (dam == null)
            {
                return false;
            }

            _repository.Remove(dam);
            return await _repository.SaveChangesAsync();
        }

        public bool DamExists(int id)
        {
            return _repository.GetByIdAsync(id) != null;
        }
    }
}
