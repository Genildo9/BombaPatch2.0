namespace BombaPatch.Application.Dtos
{
    public class GrupoDto
    {
        public int Id {get; set;}
        public string Nome { get; set; }
        public List<SelecaoDto> Selecoes {get; set;}
        public List<JogoDto> Jogos {get; set;} 
    }
}