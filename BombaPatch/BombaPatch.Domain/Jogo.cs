using bombapatch.Domain;

namespace BombaPatch.Domain
{
    public class Jogo
    {
        public int Id { get; set;}
        public int GrupoId { get; set;}
        public Selecao SelecaoA {get; set;}
        public Selecao SelecaoB {get; set;}
        public string data {get; set;}
        public int EstadioId {get; set;}
        public int ArbitroId {get; set;}
        public JogoResultado Resultado {get; set;}
        //add golspro, golscontra, cartones
        //verificar a string selecao1 e selecao2
        public Jogo()
        {
            SelecaoA = new Selecao();
            SelecaoB = new Selecao();
            Resultado = new JogoResultado();
        }
    }
}