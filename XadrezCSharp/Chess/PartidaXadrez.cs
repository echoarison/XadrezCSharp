using GameBoard;
using System.Collections.Generic;   //vamos usar um HashSet

namespace Chess
{
    internal class PartidaXadrez
    {
        //atributo autoProp
        public Tabuleiro _tabuleiro { get; private set; }
        public int _turno { get; private set; }
        public Cor _jogadorAtual { get; private set; }
        public bool _terminada { get; private set; }
        private HashSet<Peca> _pecas;   //conjunto é uma coleção de dados que obedece uma ordem
        private HashSet<Peca> _capturadas;  //conjunto é uma coleção de dados que obedece uma ordem
        public bool _xeque { get; private set; }

        //construtor
        public PartidaXadrez()
        {
            _tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            _terminada = false;
            _xeque = false;
            //tem que ser antes de colocar as pecas
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        //method
        public Peca ExecutaMovimento(Posicao origin, Posicao destino)
        {
            //fazendo o movimento como estivesse jogando
            Peca p = _tabuleiro.RetirarPeca(origin);

            //executando o movimento
            p.IncrementarQtdMovimentos();

            //setiver peca na casa aonde foi jogado ela vai ser capturada
            Peca pecaCapturar = _tabuleiro.RetirarPeca(destino);

            //colocando a peca no local
            _tabuleiro.ColocarPeca(p, destino);

            //add uma codição para pecaCapturadas
            if (pecaCapturar != null)
            {
                _capturadas.Add(pecaCapturar);
            }

            return pecaCapturar;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            //instanciando peca
            Peca p = _tabuleiro.RetirarPeca(destino);

            //desfazendo o movimento
            p.DescrementarQtdMovimentos();

            //verificando se a peca é diferente de null
            if (pecaCapturada != null)
            {
                _tabuleiro.ColocarPeca(pecaCapturada, destino);
                _capturadas.Remove(pecaCapturada);
            }

            _tabuleiro.ColocarPeca(p, origem);

        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            //fazendo o movimento
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            //verifica se esse movimento estou em cheque
            if (EstaEmXeque(_jogadorAtual))
            {
                //desfazer a jogada
                DesfazMovimento(origem, destino, pecaCapturada);

                //fazendo uma execeção
                throw new TabuleiroException("Você não pode se colocar em xeque!!!");

            }

            //se deu xeque
            if (EstaEmXeque(Adversaria(_jogadorAtual)))
            {

                _xeque = true;

            }
            else
            {

                _xeque = false;

            }

            //se ele ta em xequemate
            if (TesteXequeMate(Adversaria(_jogadorAtual)))
            {
                _terminada = true;
            }
            else
            {
                //mudando o turno
                _turno++;

                //muda jogador
                MudaJogador();
            }

        }

        public void ValidarPosicaoDeOrigem(Posicao position)
        {
            //verificando se tem peca nessa posicao
            if (_tabuleiro.PecaMth(position) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            //verificando se jogador da partida atual e igual as peças que ele
            if (_jogadorAtual != _tabuleiro.PecaMth(position).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            //verificando se não existe movimentos possiveis
            if (!_tabuleiro.PecaMth(position).ExisteMovimentoPossiveis())
            {
                throw new TabuleiroException("Não há movimento possiveis para a peça de origem escolhida!");
            }
        }

        //validando o destino
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            //verificando se não pode mover
            if (!_tabuleiro.PecaMth(origem).PodeMoverPeca(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida!!!");
            }
        }

        //method private
        private void MudaJogador()
        {
            if (_jogadorAtual == Cor.Branca)
            {
                //mudando de cor
                _jogadorAtual = Cor.Preta;
            }
            else
            {
                _jogadorAtual = Cor.Branca;
            }
        }

        //vai retornar um conjunto de pecas capturadas da cor especifica
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            //criando um variavel temp
            HashSet<Peca> aux = new HashSet<Peca>();

            //fazendo um foreach para verificar o conjunto
            foreach (Peca item in _capturadas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }

            return aux;

        }

        //vai retornar as peças que estão em jogo ainda
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            //criando um variavel temp
            HashSet<Peca> aux = new HashSet<Peca>();

            //fazendo um foreach para verificar o conjunto
            foreach (Peca item in _pecas)
            {
                if (item.Cor == cor)
                {
                    aux.Add(item);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor)); //vou tirar todas as pecas da cor Execeto as que foram capturadas

            return aux;

        }

        private Cor Adversaria(Cor cor)
        {

            //verificando a cor adversaria
            if (cor == Cor.Branca)
            {

                return Cor.Preta;

            }
            else
            {

                return Cor.Branca;

            }

        }

        private Peca Rei(Cor cor)
        {
            //verificando a cor do Rei
            foreach (Peca item in PecasEmJogo(cor))
            {

                //verificando se a varivel item é uma istancia de Rei
                if (item is Rei)
                {
                    return item;
                }

            }

            return null; //não tem Rei
        }

        public bool EstaEmXeque(Cor cor)
        {
            //variavel tmp
            bool valueVerificado = false;

            //instanciando uma peca
            Peca R = Rei(cor);

            //verificando se existe rei
            if (R == null)
            {

                throw new TabuleiroException("Não existe Rei da cor " + cor + "no tabuleiro!!");

            }

            //verificando cada peças adversaria que pode da xeque no rei
            foreach (Peca item in PecasEmJogo(Adversaria(cor)))
            {
                //variavel temp
                bool[,] matz = item.MovimentosPossiveis();

                if (matz[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    valueVerificado = true;
                }

            }

            return valueVerificado;
        }

        public bool TesteXequeMate(Cor cor)
        {
            //variavel tmp
            bool valueVerificado = true;

            //verificando se ta em xeque
            if (!EstaEmXeque(cor))
            {
                valueVerificado = false;
            }


            foreach (Peca item in PecasEmJogo(cor))
            {
                //vendo se tem todos os movimentos possiveis
                bool[,] matz = item.MovimentosPossiveis();

                //criando um for das linhas
                for (int i = 0; i < _tabuleiro.Linhas; i++)
                {
                    //criando outro for para colunas
                    for (int j = 0; j < _tabuleiro.Colunas; j++)
                    {
                        //vendo um movimento possivel de tirar o xeque
                        if (matz[i, j])
                        {
                            //instanciando o novo destino
                            Posicao origem = item.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);

                            //vendo se ainda esta em xeque
                            bool testeXeque = EstaEmXeque(cor);

                            //desfazendo o movimento
                            DesfazMovimento(origem, destino, pecaCapturada);

                            //verificando se deixou de estar em xeque
                            if (!testeXeque)
                            {
                                valueVerificado = false;
                            }

                        }
                    }
                }
            }

            return valueVerificado;
        }

        //method aux

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            //vai colocar pecas no tabuleiro
            _tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());

            _pecas.Add(peca);   //dizendo que essa pecas faz parte do meu conjunto da partida

        }

        private void ColocarPecas()
        {
            //Usando a Class PosicaoXadrez() e o method ToPosicao

            ColocarNovaPeca('c', 1, new Torre(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 7, new Torre(_tabuleiro, Cor.Branca));
            /*ColocarNovaPeca('e', 2, new Torre(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(_tabuleiro, Cor.Branca));*/

            ColocarNovaPeca('a', 8, new Rei(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Torre(_tabuleiro, Cor.Preta));
            /*ColocarNovaPeca('d', 7, new Torre(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(_tabuleiro, Cor.Preta));*/

        }
    }
}
