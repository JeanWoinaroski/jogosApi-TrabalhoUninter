using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProjetoFaculdade.DTOs;
using ProjetoFaculdade.Models;
using ProjetoFaculdade.Services.Interfaces;

namespace ProjetoFaculdade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        public EmpresasController(IEmpresaService empresaService, IMapper mapper)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _empresaService.GetAllAsync();
            var read = _mapper.Map<List<EmpresaReadDto>>(empresas);
            return Ok(read);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);
            if (empresa == null) return NotFound();
            var read = _mapper.Map<EmpresaReadDto>(empresa);
            return Ok(read);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmpresaCreateDto dto)
        {
            var empresa = _mapper.Map<Empresa>(dto);
            var created = await _empresaService.CreateAsync(empresa);
            var read = _mapper.Map<EmpresaReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpresaUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var existing = await _empresaService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var empresa = _mapper.Map<Empresa>(dto);
            var updated = await _empresaService.UpdateAsync(empresa);
            var read = _mapper.Map<EmpresaReadDto>(updated);
            return Ok(read);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _empresaService.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _empresaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
