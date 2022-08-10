using System;
using Tabuleiro;

namespace XadrezCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instanciando objeto
            Posicao P;

            P = new Posicao(3,4);

            Console.WriteLine("Posição: " + P);

            Console.ReadLine();
        }
    }
}
