using System;
using GameBoard;
using Chess;

namespace XadrezCSharp
{
    internal class Tela
    {
        //method static
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
                    //fazendo um if para ver se tem alguma peca no local
                    if (tab.PecaMth(i, j) == null)
                    {
                        Console.Write("- ");    //vai imprimir um traço demonstrando espaço vazio
                    }
                    else
                    {
                        //Console.Write(tab.PecaMth(i, j) + " "); //vai mostrar a peça no espaço
                        Tela.ImprimirPecas(tab.PecaMth(i,j));
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();

            }

            Console.WriteLine("  a b c d e f g h");

        }

        public static PosicaoXadrez LerPosicaoXadrez() 
        {
            string s = Console.ReadLine();    //vai pegar a posicao do GameBoardChess
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna,linha); 
        }

        public static void ImprimirPecas(Peca peca)
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

        }
    }
}
