namespace BombaPatch.Application.Dtos
{
    public class GrupoClassificacaoDto
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int SelecaoId { get; set; }
        public int Posicao { get; set; }

        public int Criterio1Pontos { get; set; }
        public int Criterio2SaldoGols { get; set; }
        public int Criterio3GolsMarcados { get; set; }
        public int Criterio4CartoesVermelhos { get; set; }
        public int Criterio5CartoesAmarelos { get; set; }
    }
}