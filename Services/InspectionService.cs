using DamInspectionApi.Models;
using DamInspectionApi.Repositories.Interfaces;
using DamInspectionApi.Services.Interfaces;

namespace DamInspectionApi.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IDamRepository _damRepository;

        public InspectionService(IInspectionRepository inspectionRepository, IDamRepository damRepository)
        {
            _inspectionRepository = inspectionRepository;
            _damRepository = damRepository;
        }

        public async Task<IEnumerable<Inspection>> GetAllAsync()
        {
            return await _inspectionRepository.GetAllAsync();
        }

        public async Task<Inspection?> GetByIdAsync(int id)
        {
            return await _inspectionRepository.GetByIdAsync(id);
        }

        public async Task<Inspection> CreateAsync(Inspection inspection)
        {
            // Buscar a barragem pelo DamId
            var dam = await _damRepository.GetByIdAsync(inspection.DamId);
            if (dam == null)
            {
                throw new Exception("Barragem não encontrada");
            }

            // Associar a barragem à inspeção
            inspection.Dam = dam;

            await _inspectionRepository.AddAsync(inspection);
            await _inspectionRepository.SaveChangesAsync();

            return inspection;
        }

        public async Task<bool> UpdateAsync(int id, Inspection inspection)
        {
            if (id != inspection.Id)
            {
                return false;
            }

            // Buscar a barragem pelo DamId
            var dam = await _damRepository.GetByIdAsync(inspection.DamId);
            if (dam == null)
            {
                throw new Exception("Barragem não encontrada");
            }

            // Associar a barragem à inspeção
            inspection.Dam = dam;

            _inspectionRepository.Update(inspection);
            return await _inspectionRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var inspection = await _inspectionRepository.GetByIdAsync(id);
            if (inspection == null)
            {
                return false;
            }

            _inspectionRepository.Remove(inspection);
            return await _inspectionRepository.SaveChangesAsync();
        }

        public bool InspectionExists(int id)
        {
            return _inspectionRepository.GetByIdAsync(id) != null;
        }
    }
}
