using GameBoard;

namespace Chess
{
    internal class PosicaoXadrez
    {
        //atributo autoProp
        public int Linha { get; set; }
        public char Coluna { get; set; }

        //construtor
        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;

        }

        //Method

        //convertendo a posicao do xadrez para a posicao de matriz
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        //override
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
