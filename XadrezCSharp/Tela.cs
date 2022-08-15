using System;
using System.Collections.Generic;
using GameBoard;
using Chess;

namespace XadrezCSharp
{
    internal class Tela
    {
        //method static

        public static void ImprimirPartida(PartidaXadrez partida)
        {
            //imprimindo o tabuçeiro
            ImprimirTabuleiro(partida._tabuleiro);
            Console.WriteLine();

            //vai imprimir pecas capturadas
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();

            //escrevendo o turno
            Console.WriteLine("Turno: " + partida._turno);

            //verificando se partida fpo terminada
            if (!partida._terminada)
            {
                Console.WriteLine("Aguardando jogada do jogador: " + partida._jogadorAtual);
                
                //exibindo o xeque
                if (partida._xeque)
                {

                    Console.WriteLine();
                    Console.WriteLine("Você esta em Xeque!!!");

                }
            }
            else
            {
                Console.WriteLine("XequeMate!!");
                Console.WriteLine("Vencedor: " + partida._jogadorAtual);
            }
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Pecas Capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            //fazendo um foreach para acessas os dados do conjunto
            foreach (Peca item in conjunto)
            {
                Console.Write(item + " ");
            }

            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {

            //linhas
            for (int i = 0; i < tab.Linhas; i++)
            {
                //imprimindo os numeros do tabuleiro
                Console.Write(8 - i + " ");
                //colunas
                for (int j = 0; j < tab.Colunas; j++)
                {

                    Tela.ImprimirPecas(tab.PecaMth(i, j));

                }

                Console.WriteLine();

            }

            Console.WriteLine("  a b c d e f g h");

        }

        //sobrecarga do ImprimirTabuleiro
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            //guardando o fundo da tela
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            //linhas
            for (int i = 0; i < tab.Linhas; i++)
            {
                //imprimindo os numeros do tabuleiro
                Console.Write(8 - i + " ");

                //colunas
                for (int j = 0; j < tab.Colunas; j++)
                {
                    //fazendo um if para imprimir as posicões possiveis
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    //vai imprimir a pecas
                    ImprimirPecas(tab.PecaMth(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();

            }

            Console.WriteLine("  a b c d e f g h");

            //Para ter certeza que o fundo vai ser original
            Console.BackgroundColor = fundoOriginal;

        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();    //vai pegar a posicao do GameBoardChess
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPecas(Peca peca)
        {
            //verificando se tem peças na posicao orientada
            if (peca == null)
            {
                Console.Write("- ");    //vai imprimir um traço demonstrando espaço vazio
            }
            else
            {

                //verificando a cor da peca
                if (peca.Cor == Cor.Branca)
                {

                    Console.Write(peca);

                }
                else
                {
                    //colocando a cor da peca preta
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");

            }

        }
    }
}
