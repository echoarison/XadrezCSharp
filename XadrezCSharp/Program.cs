using System;
using GameBoard;
using Chess;

namespace XadrezCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
             * 
             * Usando o try catch para exibir a message na 
             * exeção criada
             * 
             **/
            try
            {
                //instanciando objeto Tabuleiro
                Tabuleiro tab = new Tabuleiro(8, 8);

                /*Colocando peca*/
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 9));

                //usando o method static Do objeto Tela
                Tela.ImprimirTabuleiro(tab);


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}