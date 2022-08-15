﻿using GameBoard;

namespace Chess
{
    internal class Torre : Peca
    {
        //atributo AutoProp

        //Construtor
        public Torre(Tabuleiro tab, Cor cor) 
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

            Posicao position = new Posicao(0, 0);

            /*Movimentação da Torre*/

            //direcao acima
            position.DefinirValor(Posicao.Linha - 1, Posicao.Coluna );
            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position)) 
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if(Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != this.Cor){

                    break;  //dando um break do while(loop)

                }

                position.Linha = position.Linha - 1; 

            }

            //direcao abaixo
            position.DefinirValor(Posicao.Linha + 1, Posicao.Coluna);
            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != this.Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.Linha = position.Linha + 1;

            }

            //direcao direita
            position.DefinirValor(Posicao.Linha, Posicao.Coluna + 1);
            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != this.Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.Coluna = position.Coluna + 1;

            }

            //direcao esquerda
            position.DefinirValor(Posicao.Linha, Posicao.Coluna - 1);
            //fazendo um while para chegar no final
            while (Tabuleiro.PosicaoValida(position) && PodeMover(position))
            {
                matz[position.Linha, position.Coluna] = true;

                //forçando uma parada quando bater em uma peça adversaria
                if (Tabuleiro.PecaMth(position) != null && Tabuleiro.PecaMth(position).Cor != this.Cor)
                {

                    break;  //dando um break do while(loop)

                }

                position.Coluna = position.Coluna - 1;

            }

            return matz;    //retornando a matriz

        }

        //override
        public override string ToString()
        {
            return "T";
        }

    }
}
