using GameBoard;

namespace Chess
{
    internal class Torre : Peca
    {
        //atributo AutoProp

        //Construtor
        public Torre(Tabuleiro tab, Cor cor) 
            : base(tab,cor)
        {

        }

        //override
        public override string ToString()
        {
            return "T";
        }

    }
}
