namespace bombapatch.api.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int QuantidadeJogador { get; set; }

        public Time(string nome, int quantidadeJogador)
        {
            this.Nome = nome;
            this.QuantidadeJogador = quantidadeJogador;
        }
    }
}