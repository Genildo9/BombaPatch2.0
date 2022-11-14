using BombaPatch.Domain.Enum;

namespace BombaPatch.Domain
{
    public class Eliminatoria
    {
        public int Id { get; set; } 
        public int NumeroJogo { get; set; }
        public FaseEnum Fase { get; set; }
        public int SelecaoA { get; set; }
        public int SelecaoB { get; set; }
        public int SelecaoVencedora { get; set; }
        public int SelecaoPerdedora { get; set; }
    }
}