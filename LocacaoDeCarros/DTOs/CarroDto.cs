using System.ComponentModel.DataAnnotations;

namespace LocacaoDeCarros.DTOs;

public class CarroDto
{
    [Required]
    [MaxLength(100)]
    //string.Empty = string inicia com valor vazio equanto o objeto pe criado, antes de receber os dados da requisição
    public string Modelo { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Marca { get; set; } = string.Empty;

    [Required]
    public int Ano { get; set; }

    [Required]
    public decimal ValorDiaria { get; set; }
}
