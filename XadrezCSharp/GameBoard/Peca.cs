

namespace GameBoard
{
    abstract class Peca
    {
        /**
         * 
         * Só a Class mãe e as subClass pode acessa os 
         * Atributos Cor e QtdMoviment
         * 
         **/
        //atributos AutoProp
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }

        public int QtdMoviment { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        //Construtor
        public Peca(Tabuleiro tabuleiro, Cor cor) 
        {
            Posicao = null; //Quando começa um jogo a peça tem uma posicao null
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdMoviment = 0;    //não fez nenhum movimento
        }

        //Method
        public void IncrementarQtdMovimentos() 
        {
            QtdMoviment++;
        }

        //vendo se existe movimentos possiveis
        public bool ExisteMovimentoPossiveis() 
        {
            //pegando o method abstract
            bool[,] matz = MovimentosPossiveis();
            bool velueVerificado = false;

            //fazendo um for para verificar as linhas
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                //agora as colunas
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    //verificando se existe movimento possivel para a peca
                    if (matz[i, j] == true)
                    {
                        velueVerificado = true;
                    }

                }
            }

            return velueVerificado;

        }

        //Method abstract
        public abstract bool[,] MovimentosPossiveis();
    }
}
