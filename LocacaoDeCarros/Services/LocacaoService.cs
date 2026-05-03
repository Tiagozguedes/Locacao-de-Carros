using LocacaoDeCarros.Data;
using LocacaoDeCarros.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LocacaoDeCarros.Services;

public class LocacaoService
{
    private readonly AppDbContext _context;

    public LocacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LocacaoResponseDto> CalcularAsync(LocacaoRequestDto request)
    {
        var carro = await _context.Carros.FindAsync(request.CarroId);

        if (carro is null)
            throw new KeyNotFoundException("Carro não encontrado");

        int dias = request.DataFim.DayNumber - request.DataInicio.DayNumber;

        if (dias <= 0)
            throw new ArgumentException("A data de fim deve ser maior que a data de início");

        decimal subtotal = dias * carro.ValorDiaria;

        decimal percentualDesconto = 0;
        if (dias >= 7)
            percentualDesconto = 10;
        else if (dias >= 3)
            percentualDesconto = 5;

        decimal valorFinal = subtotal - (subtotal * percentualDesconto / 100);

        return new LocacaoResponseDto
        {
            Carro = carro.Modelo,
            Marca = carro.Marca,
            DataInicio = request.DataInicio,
            DataFim = request.DataFim,
            ValorDiaria = carro.ValorDiaria,
            Subtotal = subtotal,
            Desconto = percentualDesconto > 0 ? $"{percentualDesconto}%" : "Sem desconto",
            ValorFinal = valorFinal
        };
    }
}
