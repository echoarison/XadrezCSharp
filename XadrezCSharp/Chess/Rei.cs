using GameBoard;

namespace Chess
{
    /**
     * 
     * SubClass de Peca
     * 
     **/
    internal class Rei : Peca
    {

        //atributo AutoProp

        //construtor
        public Rei(Tabuleiro tab, Cor cor)
            : base(tab,cor)
        {
            
        }

        //override
        public override string ToString()
        {
            return "R";
        }
    }
}
