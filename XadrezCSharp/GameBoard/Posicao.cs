
/**
 * 
 * Mudando o namespace 
 * 
 **/
namespace GameBoard
{
    internal class Posicao
    {
        //atributo (autoProp)
        public int Linha { get; set; }
        public int Coluna { get; set; }

        //Construtor
        public Posicao() 
        { 
        
        }

        public Posicao(int linha, int coluna) 
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        //methods

        //Esse method serve para definir os valores da posicao
        public void DefinirValor(int linha, int coluna) 
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        //override
        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
