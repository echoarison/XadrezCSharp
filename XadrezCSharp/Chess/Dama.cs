using GameBoard;

namespace Chess
{
    //herdando da classe Peca
    internal class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor)
            : base(tab, cor)
        {

        }

        //override
        public override string ToString()
        {
            return "D";
        }

        //methods
        private bool PodeMover(Posicao position)
        {
            //instanciando peca
            Peca p = Tabuleiro.PecaMth(position);

            //retornando
            return p == null || p.Cor != this.Cor;
        }

        //methods abstract
        public override bool[,] MovimentosPossiveis()
        {
            //uma matriz que vai possui o numero de linhas e colunas do tabuleiro
            bool[,] matz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao position = new Posicao(0, 0);

            /*Movimentação do Dama*/

            //esquerda
            position.DefinirValor(Posicao.Linha, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;

                }

                position.DefinirValor(position.Linha, position.Coluna - 1);

            }

            //Direita
            position.DefinirValor(Posicao.Linha, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;

                }

                position.DefinirValor(position.Linha, position.Coluna + 1);

            }

            //acima
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna);

            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;

                }

                position.DefinirValor(position.Linha - 1, position.Coluna);

            }

            //abaixo
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);

            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {

                matz[position.Linha, position.Coluna] = true;

                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;

                }

                position.DefinirValor(position.Linha + 1, position.Coluna);

            }

            //Noroeste
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);

            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.DefinirValor(position.Linha - 1, position.Coluna - 1);

            }

            //Nordeste
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 1);

            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.DefinirValor(position.Linha - 1, position.Coluna + 1);

            }

            //Sudeste
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 1);

            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.DefinirValor(position.Linha + 1, position.Coluna + 1);

            }

            //Sudoeste
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 1);

            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.DefinirValor(position.Linha + 1, position.Coluna - 1);

            }

            return matz;    //retornando a matriz

        }
    }
}
