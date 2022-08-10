

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

        public Peca PecaMth(int linha, int coluna) { 
            
            return Pecas[linha,coluna];

        }

        public void ColocarPeca(Peca p, Posicao position) 
        {
            //falando que eu quero a pecas que esta na posicao linha E coluna
            Pecas[position.Linha, position.Coluna] = p;

            //aqui estou dizendo agora a posicao dessa peça é posistion
            p.Posicao = position;

        }
    }
}
