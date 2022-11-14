using BombaPatch.Domain;

namespace bombapatch.Domain
{
    public class Selecao
    {
        public int Id { get; set; } 

        public string Nome { get; set; }

        public string Continente { get; set; } 

        public int QtdJogadores { get; set; }

        public int GrupoId { get; set; }
        public int GrupoSelecaoId { get; set; }
        
    }
    
}
