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
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);

                Console.WriteLine(pos.ToPosicao());

                Console.WriteLine();

                Console.WriteLine(pos);


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}