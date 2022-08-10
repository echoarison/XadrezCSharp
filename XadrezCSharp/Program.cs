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

                //criando um laço ate a partida terminar
                while (!partida._terminada)
                {
                    //limpando a tela
                    Console.Clear();

                    //usando o method static Do objeto Tela
                    Tela.ImprimirTabuleiro(partida._tabuleiro);

                    Console.WriteLine();
                    Console.WriteLine();

                    //posicao de origem
                    Console.Write("Digite a posicao de origem: ");

                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    //posicao de destino
                    Console.Write("Digite a posicao de destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    //executar o movimento
                    partida.ExecutaMovimento(origem, destino);
                }
                


            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}