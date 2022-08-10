
/**
 * 
 * Mudando o namespace 
 * 
 **/
namespace Tabuleiro
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

        //override
        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
