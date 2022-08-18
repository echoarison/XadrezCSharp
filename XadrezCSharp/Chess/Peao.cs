using GameBoard;

namespace Chess
{
    internal class Peao : Peca
    {
        //atributo
        private PartidaXadrez Partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez partida) 
            : base(tab, cor)
        {
            Partida = partida;
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

                //#jogadaEspecial en Passant
                if (Posicao.Linha == 3)
                {
                    //vendo se  o peao esta na esquerda e pode receber o en passant
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                    //verificando se tudo é verdade
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigos(esquerda) 
                        && Tabuleiro.PecaMth(esquerda) == Partida._vulneravelEnPassant) 
                    {
                        matz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    //vendo se  o peao esta na esquerda e pode receber o en passant
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    //verificando se tudo é verdade
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigos(direita)
                        && Tabuleiro.PecaMth(direita) == Partida._vulneravelEnPassant)
                    {
                        matz[direita.Linha - 1, direita.Coluna] = true;
                    }
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

                //#jogadaEspecial en Passant
                if (Posicao.Linha == 4)
                {
                    //vendo se  o peao esta na esquerda e pode receber o en passant
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                    //verificando se tudo é verdade
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigos(esquerda)
                        && Tabuleiro.PecaMth(esquerda) == Partida._vulneravelEnPassant)
                    {
                        matz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    //vendo se  o peao esta na esquerda e pode receber o en passant
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    //verificando se tudo é verdade
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigos(direita)
                        && Tabuleiro.PecaMth(direita) == Partida._vulneravelEnPassant)
                    {
                        matz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return matz;

        }



    }
}
