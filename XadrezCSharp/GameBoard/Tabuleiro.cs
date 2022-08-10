

namespace GameBoard
{
    internal class Tabuleiro
    {
        //atributos
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;  //usando uma matriz para usar no objeto Peca

        //construtor
        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas,colunas];
        }

        //methods
    }
}
