using BombaPatch.Domain;

namespace BombaPatch.Application.Dtos
{
    public class JogosDto
    {
        public int Id { get; set;}
        public string Nome { get; set;}
        public IEnumerable<GrupoSelecoes>? GrupoSelecoes {get; set;}
        public DateTime? data {get; set;}
        public IEnumerable<Estadio>? Estadio {get; set;}
        public IEnumerable<Arbitro>? Arbitro {get; set;}
    }
}