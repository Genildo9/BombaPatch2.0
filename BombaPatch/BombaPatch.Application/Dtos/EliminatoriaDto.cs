using BombaPatch.Domain.Enum;

namespace BombaPatch.Application.Dtos
{
    public class EliminatoriaDto
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