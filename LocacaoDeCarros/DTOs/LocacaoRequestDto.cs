using System.ComponentModel.DataAnnotations;

namespace LocacaoDeCarros.DTOs;

public class LocacaoRequestDto
{
    [Required]
    public int CarroId { get; set; }

    [Required]
    public DateOnly DataInicio { get; set; }

    [Required]
    public DateOnly DataFim { get; set; }
}
