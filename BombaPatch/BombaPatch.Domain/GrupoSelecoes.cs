using bombapatch.Domain;

namespace BombaPatch.Domain
{
    public class GrupoSelecoes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int SelecaoId { get; set; }
        public Selecao Selecao { get; set; }
        public int Pontos { get; set; }    
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }
        public int SaldoGols { get; set; }
        public int CartaoAmarelo { get; set; }
        public int CartaoVermelho { get; set; }
        
    }
}