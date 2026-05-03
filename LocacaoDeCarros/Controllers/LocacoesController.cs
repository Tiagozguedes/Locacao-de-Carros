using LocacaoDeCarros.DTOs;
using LocacaoDeCarros.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoDeCarros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocacoesController : ControllerBase
{
    private readonly LocacaoService _locacaoService;

    public LocacoesController(LocacaoService locacaoService)
    {
        _locacaoService = locacaoService;
    }

    [HttpPost("calcular")]
    public async Task<IActionResult> Calcular([FromBody] LocacaoRequestDto request)
    {
        try
        {
            var resultado = await _locacaoService.CalcularAsync(request);
            return Ok(resultado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
