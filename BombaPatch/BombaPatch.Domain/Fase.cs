namespace BombaPatch.Domain
{
    public class Fase
    {
     public int Id { get; set; }   
     public string Nome { get; set; }
    public IEnumerable<Partida> Partidas { get; set; }   
}
}