namespace BombaPatch.Application.Dtos
{
    public class JogadorDto
    {
        public int Id { get; set; }
        public int SelecaoId { get; set; }
        public SelecaoDto? Selecao { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set; }
    }
}