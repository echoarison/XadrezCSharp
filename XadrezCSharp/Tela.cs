using System;
using GameBoard;

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
                //colunas
                for (int j = 0; j < tab.Colunas; j++)
                {
                    //fazendo um if para ver se tem alguma peca no local
                    if (tab.PecaMth(i,j) == null)
                    {
                        Console.Write("- ");    //vai imprimir um traço demonstrando espaço vazio
                    }
                    else
                    {
                        Console.Write(tab.PecaMth(i, j) + " "); //vai mostrar a peça no espaço
                    }
                }

                Console.WriteLine();

            }

        }
    }
}
