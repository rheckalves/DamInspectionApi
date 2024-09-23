using AutoMapper;
using DamInspectionApi.Application.DTOs;
using DamInspectionApi.Models;
using DamInspectionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DamInspectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionService _service;
        private readonly IMapper _mapper;

        public InspectionsController(IInspectionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Inspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionReadDto>>> GetInspections()
        {
            var inspections = await _service.GetAllAsync();
            var inspectionsDto = _mapper.Map<IEnumerable<InspectionReadDto>>(inspections);
            return Ok(inspectionsDto);
        }

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionReadDto>> GetInspection(int id)
        {
            var inspection = await _service.GetByIdAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<InspectionReadDto>(inspection));
        }

        // POST: api/Inspections
        [HttpPost]
        public async Task<ActionResult<InspectionReadDto>> PostInspection(InspectionWriteDto inspectionDto)
        {
            var inspection = _mapper.Map<Inspection>(inspectionDto);
            var createdInspection = await _service.CreateAsync(inspection);
            return CreatedAtAction(nameof(GetInspection), new { id = createdInspection.Id }, _mapper.Map<InspectionReadDto>(createdInspection));
        }

        // PUT: api/Inspections/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspection(int id, InspectionWriteDto inspectionDto)
        {
            var inspection = _mapper.Map<Inspection>(inspectionDto);
            var updated = await _service.UpdateAsync(id, inspection);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
