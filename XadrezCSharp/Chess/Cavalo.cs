using GameBoard;
namespace Chess
{
    internal class Cavalo : Peca
    {
        //atributo AutoProp

        //construtor
        public Cavalo(Tabuleiro tab, Cor cor)
            : base(tab, cor)
        {

        }

        //override
        public override string ToString()
        {
            return "C";
        }

        //methods
        private bool PodeMover(Posicao position)
        {
            //instanciando peca
            Peca p = Tabuleiro.PecaMth(position);

            //fazendo uma condição simples e abreviada
            return p == null || p.Cor != this.Cor;  //this é desnecessario, mas fica um pouco melhor

        }

        //methods abstract
        public override bool[,] MovimentosPossiveis()
        {
            //uma matriz que vai possui o numero de linhas e colunas do tabuleiro
            bool[,] matz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao position = new Posicao(0, 0);

            /*Movimentação do Cavalo*/

            //L
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            //L
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

            }

            return matz;    //retornando a matriz

        }


    }

}
