namespace BombaPatch.Domain
{
    public class Partida
    {
        public int Id { get; set; }
        public string Jogo { get; set; }
        public int FaseId { get; set; }
        public Fase Fase { get; set; }
        public string Data  { get; set; }
        public int EstadioId { get; set; }
        public Estadio Estadio { get; set; }
        public int ArbitroId { get; set; }
        public Arbitro Arbitro { get; set; }
    }
}