using BombaPatch.Application.Contratos;
using BombaPatch.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BombaPatch.Api.Controllers
{
[ApiController]
[Route("api/[controller]")]
    
    
public class PartidaController : ControllerBase
{
    private readonly IPartidaService _partidaService;
    public PartidaController(IPartidaService partidaService)
    {
        _partidaService = partidaService;

    }
    [HttpGet("nome")]
    //vai retornar todas as partidas que estão no banco de dados
    public async Task<IActionResult> Get(string nome)
    {
        try
        {
            var partidas = await _partidaService.GetAllPartidasByNomeAsync(nome);
            if (partidas == null) return NoContent();

            return Ok(partidas);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar partida. Erro: {ex.Message}");
        }
    }

    [HttpGet]
    //vai retornar todas as partidas que estão no banco de dados
    public async Task<IActionResult> Get()
    {
        try
        {
            var partidas = await _partidaService.GetAllPartidasAsync();
            if (partidas == null) return NoContent();

            return Ok(partidas);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar partidas. Erro: {ex.Message}");
        }
    }
    
    [HttpGet("{id}")]
    //vai retornar a seleção daquele id
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var partida = await _partidaService.GetAllPartidaByIdAsync(id);
            if (partida == null) return NoContent();

            return Ok(partida);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar partida. Erro: {ex.Message}");
        }
    }

    [HttpPost]
     public async Task<IActionResult> Post(PartidaDto model)
    {
        try 
        {
            var partida = await _partidaService.AddPartidas(model);
            if (partida == null) return NoContent();

            return Ok(partida);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar adicionar Partida(s). Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Put(int id, PartidaDto model)
    {
        try
        {
            var partida = await _partidaService.UpdatePartida(id, model);
            if (partida == null) return NoContent();

            return Ok(partida);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar atualizar partida(s). Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var partida = await _partidaService.GetAllPartidaByIdAsync(id);
            if (partida == null) return NoContent();

            return await _partidaService.DeletePartida(id) ?
            
                 Ok("Deletado"): 
                 throw new Exception("Ocorreu um probleminha!!");
            
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar deletar partida. Erro: {ex.Message}");
        }
        
}
}
}