

namespace GameBoard
{
    internal class Peca
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
        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor) 
        {
            Posicao = posicao;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdMoviment = 0;
        }
    }
}
