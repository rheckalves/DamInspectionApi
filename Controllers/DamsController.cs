using AutoMapper;
using DamInspectionApi.Application.DTOs;
using DamInspectionApi.Models;
using DamInspectionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DamInspectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamsController : ControllerBase
    {
        private readonly IDamService _service;
        private readonly IMapper _mapper;

        public DamsController(IDamService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Dams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DamReadDto>>> GetDams()
        {
            var dams = await _service.GetAllAsync();
            var damsDto = _mapper.Map<IEnumerable<DamReadDto>>(dams);
            return Ok(damsDto);
        }

        // GET: api/Dams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DamReadDto>> GetDam(int id)
        {
            var dam = await _service.GetByIdAsync(id);
            if (dam == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DamReadDto>(dam));
        }

        // POST: api/Dams
        [HttpPost]
        public async Task<ActionResult<DamReadDto>> PostDam(DamWriteDto damDto)
        {
            var dam = _mapper.Map<Dam>(damDto);
            var createdDam = await _service.CreateAsync(dam);
            return CreatedAtAction(nameof(GetDam), new { id = createdDam.Id }, _mapper.Map<DamReadDto>(createdDam));
        }

        // PUT: api/Dams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDam(int id, DamWriteDto damDto)
        {
            var dam = _mapper.Map<Dam>(damDto);
            var updated = await _service.UpdateAsync(id, dam);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Dams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDam(int id)
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
