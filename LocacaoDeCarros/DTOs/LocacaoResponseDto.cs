namespace LocacaoDeCarros.DTOs;

public class LocacaoResponseDto
{
    public string Carro { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public DateOnly DataInicio { get; set; }
    public DateOnly DataFim { get; set; }
    public decimal ValorDiaria { get; set; }
    public decimal Subtotal { get; set; }
    public string Desconto { get; set; } = string.Empty;
    public decimal ValorFinal { get; set; }
}
