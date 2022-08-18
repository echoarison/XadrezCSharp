using GameBoard;

namespace Chess
{
    /**
     * 
     * SubClass de Peca
     * 
     **/
    internal class Rei : Peca
    {

        //atributo AutoProp
        private PartidaXadrez Partida;  //para o rei saber o que esta acontecendo na partida e realizar o roque

        //construtor
        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida)
            : base(tab,cor)
        {
            Partida = partida;
        }

        //methods
        private bool PodeMover(Posicao position) 
        {
            //instanciando peca
            Peca p = Tabuleiro.PecaMth(position);

            //fazendo uma condição simples e abreviada
            return p == null || p.Cor != this.Cor;  //this é desnecessario, mas fica um pouco melhor

        }

        private bool TesteTorreParaRoque(Posicao position) 
        {
            Peca p = Tabuleiro.PecaMth(position);

            return p != null && p is Torre && p.Cor == Cor && p.QtdMoviment == 0;
        }

        //methods abstract
        public override bool[,] MovimentosPossiveis() 
        {
            //uma matriz que vai possui o numero de linhas e colunas do tabuleiro
            bool[,] matz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao position = new Posicao(0,0);

            /*Movimentação do Rei*/

            //fazendo uma posicao acima da posicao do Rei
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna);

            if (Tabuleiro.PosicaoValida(position) && PodeMover(position)) 
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direção nordeste
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direção direita
            position.DefinirValor(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direção sudeste
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direcao abaixo
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direcao sudoeste
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direcao esquerda
            position.DefinirValor(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            //direcao noroeste
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;
            }

            // #jogadaEspecia roque
            if (QtdMoviment == 0 && !Partida._xeque)
            {
                //#jogadaEspecia roque pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.PecaMth(p1) == null && Tabuleiro.PecaMth(p2) == null)
                    {
                        matz[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }

                }

                //#jogadaEspecia roque grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.PecaMth(p1) == null && Tabuleiro.PecaMth(p2) == null 
                        && Tabuleiro.PecaMth(p3) == null)
                    {
                        matz[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }

                }

            }

            return matz;    //retornando a matriz

        }

        //override
        public override string ToString()
        {
            return "R";
        }
    }
}
