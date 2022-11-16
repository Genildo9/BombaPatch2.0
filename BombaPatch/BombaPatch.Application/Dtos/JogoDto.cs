using BombaPatch.Domain;

namespace BombaPatch.Application.Dtos
{
    public class JogoDto
    {
        public int GrupoId {get; set;}
        public int Id {get; set;}
        public SelecaoDto SelecaoA {get; set;}
        public SelecaoDto SelecaoB {get; set;}
        public string Data {get; set;}
        public int EstadioId {get; set;}
        public int ArbitroId {get; set;}
        public JogoResultado Resultado {get; set;}

    }
}