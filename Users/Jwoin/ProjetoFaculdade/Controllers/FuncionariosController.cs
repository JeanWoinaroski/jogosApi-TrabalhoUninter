using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProjetoFaculdade.DTOs;
using ProjetoFaculdade.Models;
using ProjetoFaculdade.Services.Interfaces;

namespace ProjetoFaculdade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionariosController(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var funcionarios = await _funcionarioService.GetAllAsync();
            var read = _mapper.Map<List<FuncionarioReadDto>>(funcionarios);
            return Ok(read);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var funcionario = await _funcionarioService.GetByIdAsync(id);
            if (funcionario == null) return NotFound();
            var read = _mapper.Map<FuncionarioReadDto>(funcionario);
            return Ok(read);
        }

        [HttpGet("empresa/{empresaId}")]
        public async Task<IActionResult> GetByEmpresa(int empresaId)
        {
            var funcionarios = await _funcionarioService.GetByEmpresaAsync(empresaId);
            var read = _mapper.Map<List<FuncionarioReadDto>>(funcionarios);
            return Ok(read);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FuncionarioCreateDto dto)
        {
            var funcionario = _mapper.Map<Funcionario>(dto);
            var created = await _funcionarioService.CreateAsync(funcionario);
            var read = _mapper.Map<FuncionarioReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FuncionarioUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var existing = await _funcionarioService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var funcionario = _mapper.Map<Funcionario>(dto);
            var updated = await _funcionarioService.UpdateAsync(funcionario);
            var read = _mapper.Map<FuncionarioReadDto>(updated);
            return Ok(read);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _funcionarioService.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _funcionarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}
