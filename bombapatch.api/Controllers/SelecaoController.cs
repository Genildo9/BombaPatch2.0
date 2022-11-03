using bombapatch.api.Data;
using bombapatch.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace bombapatch.api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SelecaoController : ControllerBase
    {
               
        private readonly DataContext _context;

        public SelecaoController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        //vai retornar todas as seleções que estão no banco de dados
        public IEnumerable<Selecao> Get()
        {
            return _context.Selecoes;
        }
        [HttpGet("{id}")]
        //vai retornar a seleção daquele id
        public IEnumerable<Selecao> Get(int id)
        {
            return _context.Selecoes.Where(selecao => selecao.Id == id);
        }

        [HttpPost]

        public string Post()
        {
            return "testando as seleções no Post";
        }

        [HttpPut("{id}")]

        public string Put(int id)
        {
            return $"testando seleções com Put com id = {id}";
        }

        [HttpDelete("{id}")]

        public string Delete(int id)
        {
            return $"testando deletar as seleções com = {id}";
        }
    }
