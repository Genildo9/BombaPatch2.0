using System.ComponentModel.DataAnnotations;

namespace BombaPatch.Application.Dtos
{
    //objeto de dependencia
    public class SelecaoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O campo Nome é Obrigatorio.")]
        public string Nome { get; set; }

        public string Continente { get; set; } 

        //Validação de int
        [Display(Name ="Qtd Jogadores")]
        [Range(1, 26, ErrorMessage ="{0} Não pode ser menor que 1 e maior que 30.")]
        public int QtdJogadores { get; set; }

        public IEnumerable<JogadorDto>? Jogadores { get; set; }
        
        public IEnumerable<GrupoDto>? GruposSelecoes { get; set; }
        public int GrupoId { get; set; }
    }
}