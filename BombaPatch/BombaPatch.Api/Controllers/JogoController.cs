using BombaPatch.Persistence;
using bombapatch.Domain;
using Microsoft.AspNetCore.Mvc;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Application.Contratos;
using Microsoft.AspNetCore.Http;
using BombaPatch.Application.Dtos;
using BombaPatch.Domain;

namespace bombapatch.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JogoController : ControllerBase
{
    private readonly IJogoService _jogoService;
    public JogoController(IJogoService JogoService)
    {
        _jogoService = JogoService;

    }
    [HttpGet("nome")]
    //vai retornar todas os jogos que estão no banco de dados
    public async Task<IActionResult> Get(string nome)
    {
        try
        {
            var jogos = await _jogoService.GetAllJogosByNomeAsync(nome);
            if (jogos == null) return NoContent();

            return Ok(jogos);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar jogos. Erro: {ex.Message}");
        }
    }


    [HttpGet]
    //vai retornar todas as jogos que estão no banco de dados
    public async Task<IActionResult> Get()
    {
        try
        {
            var jogos = await _jogoService.GetAllJogosAsync();
            if (jogos == null) return NoContent();

            return Ok(jogos);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar os Jogos. Erro: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    //vai retornar o jogo daquele id
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var jogo = await _jogoService.GetAllJogoByIdAsync(id);
            if (jogo == null) return NoContent();

            return Ok(jogo);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar o Jogo. Erro: {ex.Message}");
        }
    }

    [HttpPost]

    public async Task<IActionResult> Post(JogoDto model)
    {
        try 
        {
            var jogo = await _jogoService.AddJogos(model);
            if (jogo == null) return NoContent();

            return Ok(jogo);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar criar Jogo. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Put(int id, JogoDto model)
    {
        try
        {
            var jogo = await _jogoService.UpdateJogo(id, model);
            if (jogo == null) return NoContent();

            return Ok(jogo);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar atualizar Jogo. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var jogo = await _jogoService.GetAllJogoByIdAsync(id);
            if (jogo == null) return NoContent();

            return await _jogoService.DeleteJogo(id) ?
            
                 Ok("Deletado"): 
                 throw new Exception("Ocorreu um probleminha!!");
            
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar deletar o Jogo. Erro: {ex.Message}");
        }
    }
}
