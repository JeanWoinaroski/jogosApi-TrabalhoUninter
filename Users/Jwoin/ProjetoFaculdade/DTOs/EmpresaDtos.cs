using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProjetoFaculdade.DTOs
{
    public class EmpresaCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Cnpj { get; set; } = null!;
    }

    public class EmpresaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Cnpj { get; set; } = null!;
    }

    public class EmpresaReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cnpj { get; set; } = null!;
        public List<FuncionarioReadDto> Funcionarios { get; set; } = new();
    }
}
