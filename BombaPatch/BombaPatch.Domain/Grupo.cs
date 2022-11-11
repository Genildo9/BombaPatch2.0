using bombapatch.Domain;

namespace BombaPatch.Domain
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Selecao> Selecoes {get; set;}
        
        public Grupo()
        {
            Selecoes = new List<Selecao>();
            Nome = "";
        }      

    }
}