

namespace GameBoard
{
    internal class Tabuleiro
    {
        //atributos
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;  //usando uma matriz para usar no objeto Peca

        //construtor
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        //methods

        public Peca PecaMth(int linha, int coluna)
        {

            return Pecas[linha, coluna];

        }

        //Fazendo um sobrecarga
        public Peca PecaMth(Posicao position)
        {

            return Pecas[position.Linha, position.Coluna];

        }

        //verificando se tem uma peca na posicao
        public bool ExistePeca(Posicao position)
        {
            //usando o method validarPosicao antes
            ValidarPosicao(position);

            //se tiver certo ele vem aqui depois e verifica se tem uma peca na posicao
            return PecaMth(position) != null;
        }

        public void ColocarPeca(Peca p, Posicao position)
        {
            //verificando se existe uma peca no local escolhido
            if (ExistePeca(position))
            {
                throw new TabuleiroException("Já Existi uma peça nessa posição!!!");
            }
            else
            {
                //falando que eu quero a pecas que esta na posicao linha E coluna
                Pecas[position.Linha, position.Coluna] = p;

                //aqui estou dizendo agora a posicao dessa peça é posistion
                p.Posicao = position;
            }

        }

        //testando posicao
        public bool PosicaoValida(Posicao position)
        {
            //variavel local 
            bool valido = true;

            //verificando se  a posicao é maior que 0 e menor que 7
            if (position.Linha < 0 || position.Linha >= Linhas
                || position.Coluna < 0 || position.Coluna >= Colunas)
            {
                valido = false;
            }

            //vai retorna true se o if for falso
            return valido;
        }

        public void ValidarPosicao(Posicao position)
        {
            //Verificando se não for valida o movimento
            if (!PosicaoValida(position))
            {
                throw new TabuleiroException("Posição Invalida!!");
            }
        }
    }
}
