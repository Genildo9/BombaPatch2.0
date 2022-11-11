namespace BombaPatch.Domain
{
    public class SelecaoJogoResultado
    {
        public int SelecaoId { get; set; }
        public int Pontos { get; set; }    
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }
        public int CartaoAmarelo { get; set; }
        public int CartaoVermelho { get; set; }
    }
}