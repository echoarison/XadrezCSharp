using GameBoard;

namespace Chess
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) 
            : base(tab, cor)
        {

        }

        //override
        public override string ToString()
        {
            return "P";
        }

        //method privado
        private bool ExisteInimigos(Posicao position) 
        {
            //instanciando Peca
            Peca p = Tabuleiro.PecaMth(position);

            //retornando
            return p != null && p.Cor != this.Cor;

        }

        private bool Livre(Posicao position) 
        {
            return Tabuleiro.PecaMth(position) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao position = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {

                position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(position) && Livre(position))
                {
                    matz[position.Linha, position.Coluna] = true;
                }

                position.DefinirValor(Posicao.Linha - 2, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(position) && Livre(position) && QtdMoviment == 0)
                {
                    matz[position.Linha, position.Coluna] = true;
                }

                position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna - 1);

                if (Tabuleiro.PosicaoValida(position) && ExisteInimigos(position))
                {
                    matz[position.Linha, position.Coluna] = true;
                }

                position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna + 1);

                if (Tabuleiro.PosicaoValida(position) && ExisteInimigos(position))
                {
                    matz[position.Linha, position.Coluna] = true;
                }
            }
            else 
            {
                position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(position) && Livre(position))
                {
                    matz[position.Linha, position.Coluna] = true;
                }

                position.DefinirValor(Posicao.Linha + 2, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(position) && Livre(position) && QtdMoviment == 0)
                {
                    matz[position.Linha, position.Coluna] = true;
                }

                position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna - 1);

                if (Tabuleiro.PosicaoValida(position) && ExisteInimigos(position))
                {
                    matz[position.Linha, position.Coluna] = true;
                }

                position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna + 1);

                if (Tabuleiro.PosicaoValida(position) && ExisteInimigos(position))
                {
                    matz[position.Linha, position.Coluna] = true;
                }
            }

            return matz;

        }



    }
}
