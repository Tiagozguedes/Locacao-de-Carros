using LocacaoDeCarros.DTOs;
using LocacaoDeCarros.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoDeCarros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrosController : ControllerBase
{
    private readonly CarroService _carroService;

    public CarrosController(CarroService carroService)
    {
        _carroService = carroService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var carros = await _carroService.GetAllAsync();
        return Ok(carros);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var carro = await _carroService.GetByIdAsync(id);

        if (carro is null)
            return NotFound("Carro não encontrado");

        return Ok(carro);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CarroDto dto)
    {
        var carro = await _carroService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = carro.Id }, carro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CarroDto dto)
    {
        try
        {
            var carro = await _carroService.UpdateAsync(id, dto);
            return Ok(carro);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _carroService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
