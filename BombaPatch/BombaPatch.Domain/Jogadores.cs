
using bombapatch.Domain;

namespace BombaPatch.Domain
{
    public class Jogador
    {
        public int Id { get; set; }
        public int SelecaoId { get; set; }
        public Selecao? Selecao { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
    }
}