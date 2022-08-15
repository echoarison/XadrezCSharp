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

        //construtor
        public Rei(Tabuleiro tab, Cor cor)
            : base(tab,cor)
        {
            
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

            return matz;    //retornando a matriz

        }

        //override
        public override string ToString()
        {
            return "R";
        }
    }
}
