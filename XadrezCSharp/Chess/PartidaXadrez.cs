using System;
using GameBoard;

namespace Chess
{
    internal class PartidaXadrez
    {
        //atributo autoProp
        public Tabuleiro _tabuleiro { get; private set; }
        private int _turno;
        private Cor _jogadorAtual;

        //construtor
        public PartidaXadrez() 
        {
            _tabuleiro = new Tabuleiro(8,8);
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        //method
        public void ExecutaMovimento(Posicao origin, Posicao destino) 
        {
            //fazendo o movimento como estivesse jogando
            Peca p = _tabuleiro.RetirarPeca(origin);

            //executando o movimento
            p.IncrementarQtdMovimentos();
            
            //setiver peca na casa aonde foi jogado ela vai ser capturada
            Peca pecaCapturar = _tabuleiro.RetirarPeca(destino);

            //colocando a peca no local
            _tabuleiro.ColocarPeca(p, destino);
        }

        //method aux
        private void ColocarPecas() {
            //Usando a Class PosicaoXadrez() e o method ToPosicao
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            _tabuleiro.ColocarPeca(new Rei(_tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            _tabuleiro.ColocarPeca(new Torre(_tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            _tabuleiro.ColocarPeca(new Rei(_tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
