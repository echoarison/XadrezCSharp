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

                //instanciando a partida de xadrez
                PartidaXadrez partida = new PartidaXadrez();

                //usando o method static Do objeto Tela
                Tela.ImprimirTabuleiro(partida._tabuleiro);


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}