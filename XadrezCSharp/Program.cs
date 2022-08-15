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
                    try
                    {
                        //limpando a tela
                        Console.Clear();

                        //usando o method static Do objeto Tela
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();

                        //posicao de origem
                        Console.Write("Digite a posicao de origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeOrigem(origem);  //validando a posicao

                        //mostrando os movimentos possiveis
                        bool[,] posicoesPossiveis = partida._tabuleiro.PecaMth(origem).MovimentosPossiveis();

                        //limpando a tela
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida._tabuleiro, posicoesPossiveis);
                        Console.WriteLine();

                        //posicao de destino
                        Console.Write("Digite a posicao de destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        //executar o movimento
                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Erro não cartalogado: " + e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) 
            {
                Console.Clear();
                Console.WriteLine("Erro não cartalogado: " + e.Message);

            }

            Console.ReadLine();

        }
    }
}