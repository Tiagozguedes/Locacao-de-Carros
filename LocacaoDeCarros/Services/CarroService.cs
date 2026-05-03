using LocacaoDeCarros.Data;
using LocacaoDeCarros.DTOs;
using LocacaoDeCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoDeCarros.Services;

public class CarroService
{
    private readonly AppDbContext _context;

    public CarroService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CarroResponseDto>> GetAllAsync()
    {
        var carros = await _context.Carros.ToListAsync();
        return carros.Select(ToResponse).ToList();
    }

    public async Task<CarroResponseDto?> GetByIdAsync(int id)
    {
        var carro = await _context.Carros.FindAsync(id);
        return carro is null ? null : ToResponse(carro);
    }

    public async Task<CarroResponseDto> CreateAsync(CarroDto dto)
    {
        var carro = new Carro(dto.Modelo, dto.Marca, dto.Ano, dto.ValorDiaria);
        _context.Carros.Add(carro);
        await _context.SaveChangesAsync();
        return ToResponse(carro);
    }

    public async Task<CarroResponseDto> UpdateAsync(int id, CarroDto dto)
    {
        var carro = await _context.Carros.FindAsync(id);

        if (carro is null)
            throw new KeyNotFoundException("Carro não encontrado");

        carro.Atualizar(dto.Modelo, dto.Marca, dto.Ano, dto.ValorDiaria);
        await _context.SaveChangesAsync();
        return ToResponse(carro);
    }

    public async Task DeleteAsync(int id)
    {
        var carro = await _context.Carros.FindAsync(id);

        if (carro is null)
            throw new KeyNotFoundException("Carro não encontrado");

        _context.Carros.Remove(carro);
        await _context.SaveChangesAsync();
    }

    private static CarroResponseDto ToResponse(Carro carro) => new()
    {
        Id = carro.Id,
        Modelo = carro.Modelo,
        Marca = carro.Marca,
        Ano = carro.Ano,
        ValorDiaria = carro.ValorDiaria
    };
}
