using System;
using GameBoard;

namespace XadrezCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instanciando objeto Tabuleiro
            Tabuleiro tab = new Tabuleiro(8,8);


            //usando o method static Do objeto Tela
            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
