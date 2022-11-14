using bombapatch.Domain;

namespace BombaPatch.Domain
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
       // public List<Selecao> Selecoes {get; set;}
        public int SelecaoClassificada1 { get; set; }
        public int SelecaoClassificada2 { get; set; }  
        
        public Grupo()
        {
         //   Selecoes = new List<Selecao>();
            Nome = "";
        }   
        //passar resultados das partidas do grupo
        public List<GrupoClassificacao> ClassificarGrupo(List<SelecaoJogoResultado> resultados, List<Selecao> selecoes)
        {
            var classificacao = new List<GrupoClassificacao>();
            
            foreach (var item in selecoes)
            {
                var resultadosPorSelecao = resultados.Where(x => x.SelecaoId == item.Id).ToList();

                var pontos = resultadosPorSelecao.Sum(x => x.Pontos);
                var saldoDeGols = resultadosPorSelecao.Sum(x => x.GolsMarcados) - resultadosPorSelecao.Sum(x => x.GolsSofridos);
                var golsMarcados = resultadosPorSelecao.Sum(x => x.GolsMarcados);
                var cartoesVermelhos = resultadosPorSelecao.Sum(x => x.CartaoVermelho);
                var cartoesAmarelos = resultadosPorSelecao.Sum(x => x.CartaoAmarelo);

                classificacao.Add(
                    new GrupoClassificacao {
                        SelecaoId = item.Id,
                        GrupoId = Id,
                        Criterio1Pontos = pontos,
                        Criterio2SaldoGols = saldoDeGols,
                        Criterio3GolsMarcados = golsMarcados,
                        Criterio4CartoesVermelhos =cartoesVermelhos,
                        Criterio5CartoesAmarelos=cartoesAmarelos
                        });
            }

            //classificar
            classificacao = classificacao
                .OrderBy(x => x.Criterio1Pontos)
                .ThenBy(x => x.Criterio2SaldoGols)
                .ThenBy(x => x.Criterio3GolsMarcados)
                .ThenByDescending(x => x.Criterio4CartoesVermelhos)
                .ThenByDescending(x => x.Criterio5CartoesAmarelos)
                .ToList();

            //gravar posicao
            var contadorPosicao = 1;
            for (int i = 0; i < classificacao.Count; i++)
            {
                classificacao[i].Posicao = contadorPosicao;
                contadorPosicao++;
            }

            if(classificacao.Any()) 
            {
//gravar selecoes classificadas do grupo
            SelecaoClassificada1 = classificacao[0].SelecaoId;
            SelecaoClassificada2 = classificacao[1].SelecaoId;
            }

            

            return classificacao;
        } 

    }
}