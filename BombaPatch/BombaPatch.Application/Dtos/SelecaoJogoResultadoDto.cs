namespace BombaPatch.Application.Dtos
{
    public class SelecaoJogoResultadoDto
    {
        public int Id {get; set;}
        public int SelecaoId { get; set; }
        public int Pontos { get; set; }    
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }
        public int CartaoAmarelo { get; set; }
        public int CartaoVermelho { get; set; }
    }
}