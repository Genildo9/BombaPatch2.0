namespace BombaPatch.Domain
{
    public class Arbitro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public int QtdPartidas { get; set; }
        public IEnumerable<Partida> Partida { get; set; }
        
    }
}