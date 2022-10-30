using bombapatch.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace bombapatch.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SelecaoController : ControllerBase
{
  

    public IEnumerable<Selecao> _selecao = new Selecao[]
    {
            new Selecao() {
                SelecaoId = 1,
                Nome = "Alemanha",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 2,
                Nome = "Arábia Saudita",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 3,
                Nome = "Argentina",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 4,
                Nome = "Austrália",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 5,
                Nome = "Bélgica",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 6,
                Nome = "Brasil",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 7,
                Nome = "Camarões",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 8,
                Nome = "Canadá",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 9,
                Nome = "Catar",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 10,
                Nome = "Coreia do Sul",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
                new Selecao() {
                SelecaoId = 11,
                Nome = "Costa Rica",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 12,
                Nome = "Croácia",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 13,
                Nome = "Dinamarca",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 14,
                Nome = "Equador",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 15,
                Nome = "Espanha",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 16,
                Nome = "Estados Unidos",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 17,
                Nome = "França",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 18,
                Nome = "Gana",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 9,
                Nome = "Holanda",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 20,
                Nome = "Inglaterra",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 21,
                Nome = "Irã",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
                new Selecao() {
                SelecaoId = 22,
                Nome = "Japão",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 23,
                Nome = "Marrocos",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 24,
                Nome = "México",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 25,
                Nome = "País de Gales",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 26,
                Nome = "Polônia",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 27,
                Nome = "Portugal",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 28,
                Nome = "Senegal",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 29,
                Nome = "Sérvia",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 30,
                Nome = "Suíça",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
             new Selecao() {
                SelecaoId = 31,
                Nome = "Tunísia",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            },
            new Selecao() {
                SelecaoId = 32,
                Nome = "Uruguai",
                QtdJogadores = "24",
                DataJogos = "12/12/2022",
            }

        };
    public SelecaoController()
    {
         
    }

    [HttpGet]
//vai retornar todas as seleções
    public IEnumerable<Selecao> Get()
    {
        return _selecao;
    }
    [HttpGet("{id}")]
//vai retornar a seleção daquele id
    public IEnumerable<Selecao> Get(int id)
    {
        return _selecao.Where(selecao => selecao.SelecaoId ==id);
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
