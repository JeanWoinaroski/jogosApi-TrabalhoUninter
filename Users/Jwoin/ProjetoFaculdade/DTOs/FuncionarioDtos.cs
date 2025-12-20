using System.ComponentModel.DataAnnotations;

namespace ProjetoFaculdade.DTOs
{
    public class FuncionarioCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Cargo { get; set; } = null!;

        [Required]
        public int EmpresaId { get; set; }
    }

    public class FuncionarioUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Cargo { get; set; } = null!;

        [Required]
        public int EmpresaId { get; set; }
    }

    public class FuncionarioReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public int EmpresaId { get; set; }
        public string? EmpresaNome { get; set; }
    }
}
