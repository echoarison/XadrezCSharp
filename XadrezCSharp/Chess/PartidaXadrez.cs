using GameBoard;

namespace Chess
{
    internal class PartidaXadrez
    {
        //atributo autoProp
        public Tabuleiro _tabuleiro { get; private set; }
        public int _turno { get; private set; }
        public Cor _jogadorAtual { get; private set; }
        public bool _terminada { get; private set; }

        //construtor
        public PartidaXadrez()
        {
            _tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            _terminada = false;
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

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            //fazendo o movimento
            ExecutaMovimento(origem, destino);

            //mudando o turno
            _turno++;

            //muda jogador
            MudaJogador();
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

        //method aux
        private void ColocarPecas()
        {
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
