using BombaPatch.Persistence;
using bombapatch.Domain;
using Microsoft.AspNetCore.Mvc;
using BombaPatch.Persistence.Contextos;
using BombaPatch.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace bombapatch.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SelecaoController : ControllerBase
{
    private readonly ISelecaoService _selecaoService;
    public SelecaoController(ISelecaoService selecaoService)
    {
        _selecaoService = selecaoService;

    }
    [HttpGet("nome")]
    //vai retornar todas as seleções que estão no banco de dados
    public async Task<IActionResult> Get(string nome)
    {
        try
        {
            var selecoes = await _selecaoService.GetAllSelecoesByNomeAsync(nome);
            if (selecoes == null) return NotFound("Nenhuma seleção encontrada.");

            return Ok(selecoes);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar seleções. Erro: {ex.Message}");
        }
    }


    [HttpGet]
    //vai retornar todas as seleções que estão no banco de dados
    public async Task<IActionResult> Get()
    {
        try
        {
            var selecoes = await _selecaoService.GetAllSelecoesAsync();
            if (selecoes == null) return NotFound("Nenhuma seleção encontrada.");

            return Ok(selecoes);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar seleções. Erro: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    //vai retornar a seleção daquele id
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var selecao = await _selecaoService.GetAllSelecaoByIdAsync(id);
            if (selecao == null) return NotFound("Nenhuma seleção encontrada.");

            return Ok(selecao);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar seleções. Erro: {ex.Message}");
        }
    }

    [HttpPost]

    public async Task<IActionResult> Post(Selecao model)
    {
        try 
        {
            var selecao = await _selecaoService.AddSelecoes(model);
            if (selecao == null) return BadRequest("Erro ao tentar adicionar seleção.");

            return Ok(selecao);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar seleções. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Put(int id, Selecao model)
    {
        try
        {
            var selecao = await _selecaoService.UpdateSelecao(id, model);
            if (selecao == null) return BadRequest("Erro ao tentar adicionar seleção.");

            return Ok(selecao);
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar atualizar seleções. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if(await _selecaoService.DeleteSelecao(id))
            {
                return Ok("Deletado");
            }
            else
            {
                return BadRequest("Seleção não deletada.");
            }
        }
        catch (Exception ex)
        { 
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar deletar seleções. Erro: {ex.Message}");
        }
    }
}
