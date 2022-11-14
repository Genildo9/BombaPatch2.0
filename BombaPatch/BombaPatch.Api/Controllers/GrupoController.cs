using BombaPatch.Persistence;
using bombapatch.Domain;
using Microsoft.AspNetCore.Mvc;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Application.Contratos;
using Microsoft.AspNetCore.Http;
using BombaPatch.Application.Dtos;

namespace bombapatch.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GrupoController : ControllerBase
{
    private readonly IGrupoService _grupoService;
    public GrupoController(IGrupoService grupoService)
    {
        _grupoService = grupoService;

    }
   [HttpGet]
    //vai retornar todas os grupos que estão no banco de dados
    public async Task<IActionResult> Get()
    {
        try
        {
            var grupos = await _grupoService.GetAllGrupoAsync();
            if (grupos == null) return NoContent();

            return Ok(grupos);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar grupos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{nome}")] // nome
    public async Task<IActionResult> Get(string nome)
    {
        try
        {
            var grupos = await _grupoService.GetAllGruposByNomeAsync(nome);
            if (grupos == null) return NoContent();

            return Ok(grupos);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar os grupos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    //vai retornar o grupo daquele id
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var grupo = await _grupoService.GetAllGrupoByIdAsync(id);
            if (grupo == null) return NoContent();

            return Ok(grupo);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar o grupo. Erro: {ex.Message}");
        }
    }
   

    [HttpPost]

    public async Task<IActionResult> Post(GrupoDto model)
    {
        try 
        {
            var grupo = await _grupoService.AddGrupo(model);
            if (grupo == null) return NoContent();

            return Ok(grupo);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar Grupo. Erro: {ex.Message}");
        }
    }

    
   
    
}
