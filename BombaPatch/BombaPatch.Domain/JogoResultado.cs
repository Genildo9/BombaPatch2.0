namespace BombaPatch.Domain
{
    public class JogoResultado
    {
        public int Id {get; set;}
        public SelecaoJogoResultado SelecaoJogoResultadoA {get; set;}
        public SelecaoJogoResultado SelecaoJogoResultadoB {get; set;}
        public string Resultado {get; set;}


        public JogoResultado()
        {
            SelecaoJogoResultadoA = new SelecaoJogoResultado();
            SelecaoJogoResultadoB = new SelecaoJogoResultado();
            Resultado = "";
        }
        public void CalcularResultado()
        {
            if (SelecaoJogoResultadoA.GolsMarcados == SelecaoJogoResultadoB.GolsMarcados)
            {
                Resultado = "ficou empatado.";
            }else if (SelecaoJogoResultadoA.GolsMarcados > SelecaoJogoResultadoB.GolsMarcados)
            {
                Resultado = "SelecaoA foi a vencedora";
            }else
            {
                Resultado = "A seleçãoB foi a vencedora";
            }
            
        }
    }
}