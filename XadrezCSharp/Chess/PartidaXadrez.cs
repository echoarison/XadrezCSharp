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
        public Peca _vulneravelEnPassant { get; private set; }

        //construtor
        public PartidaXadrez()
        {
            _tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            _terminada = false;
            _xeque = false;
            _vulneravelEnPassant = null;
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

            // #jogadaEspecial Roque pequeno
            if (p is Rei && destino.Coluna == origin.Coluna + 2)
            {
                //pegando a origem da torre
                Posicao origemT = new Posicao(origin.Linha, origin.Coluna + 3);
                Posicao destinoT = new Posicao(origin.Linha, origin.Coluna + 1);

                //retirando a peca
                Peca T = _tabuleiro.RetirarPeca(origemT);

                //fazendo o movimento
                T.IncrementarQtdMovimentos();
                _tabuleiro.ColocarPeca(T, destinoT);
            }

            // #jogadaEspecial Roque grande
            if (p is Rei && destino.Coluna == origin.Coluna - 2)
            {
                //pegando a origem da torre
                Posicao origemT = new Posicao(origin.Linha, origin.Coluna - 4);
                Posicao destinoT = new Posicao(origin.Linha, origin.Coluna - 1);

                //retirando a peca
                Peca T = _tabuleiro.RetirarPeca(origemT);

                //fazendo o movimento
                T.IncrementarQtdMovimentos();
                _tabuleiro.ColocarPeca(T, destinoT);
            }

            //#jogadaEspecial En Passant
            if (p is Peao ) 
            {
                if (origin.Coluna != destino.Coluna && pecaCapturar == null) 
                {
                    Posicao posP;

                    if (p.Cor == Cor.Branca) 
                    {
                        //uma peça a ser capturada uma linha abaixo
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else
                    {
                        //uma peça a ser capturada uma linha abaixo
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }

                    pecaCapturar = _tabuleiro.RetirarPeca(posP);

                    //pecaCapturada
                    _capturadas.Add(pecaCapturar);

                }
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

            // #jogadaEspecial Roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                //pegando a origem da torre
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);

                //retirando a peca
                Peca T = _tabuleiro.RetirarPeca(destinoT);

                //fazendo o desfazendo o movimento
                T.DescrementarQtdMovimentos();
                _tabuleiro.ColocarPeca(T, origemT);
            }

            // #jogadaEspecial Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                //pegando a origem da torre
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);

                //retirando a peca
                Peca T = _tabuleiro.RetirarPeca(destinoT);

                //fazendo o desfazendo o movimento
                T.DescrementarQtdMovimentos();
                _tabuleiro.ColocarPeca(T, origemT);
            }

            //#jogadaEspecial en Passant
            if (p is Peao) 
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada 
                    == _vulneravelEnPassant) 
                {
                    //retirando a peca
                    Peca peao = _tabuleiro.RetirarPeca(destino);

                    Posicao posP;

                    if (p.Cor == Cor.Branca)
                    {
                        posP = new Posicao(3, destino.Coluna);
                    }
                    else
                    {
                        posP = new Posicao(4,destino.Coluna);
                    }

                    _tabuleiro.ColocarPeca(peao, posP);

                }
            }

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

            //Pegando qual peça foi movimentada
            Peca p = _tabuleiro.PecaMth(destino);

            //#jogadaEspecial Promoção
            if (p is Peao)
            {
                //jogada de promocao
                if ((p.Cor == Cor.Branca && destino.Linha == 0) || 
                    (p.Cor == Cor.Preta && destino.Linha == 7)) 
                {
                    p = _tabuleiro.RetirarPeca(destino);    //retirando a peca

                    _pecas.Remove(p);   //removendo a peca

                    //criando uma promocao
                    Peca dama = new Dama(_tabuleiro, p.Cor);
                    _tabuleiro.ColocarPeca(dama, destino);  //colocando no lugar do peao
                    _pecas.Add(dama);   //add a lista de pecas
                }
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

            //#jogadaEspecial En Passant
            if (p is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2)) 
            {
                _vulneravelEnPassant = p;
            }
            else
            {
                _vulneravelEnPassant = null;
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
            if (!_tabuleiro.PecaMth(origem).MovimentoPossivel(destino))
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

            ColocarNovaPeca('a', 1, new Torre(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(_tabuleiro, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(_tabuleiro, Cor.Branca, this));    //acessando o proprio objeto
            ColocarNovaPeca('b', 2, new Peao(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(_tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(_tabuleiro, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(_tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(_tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(_tabuleiro, Cor.Preta, this));

        }
    }
}
