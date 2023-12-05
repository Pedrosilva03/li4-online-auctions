namespace app.Leiloeira.Lances
{
    public class Lance
    {
        private int id;
        private int id_leilão;
        private int id_licitador;
        private decimal valor;

        //CONSTRUTORES//

        public Lance (int id, int id_leilão, int id_licitador, decimal valor){
            this.id = id;
            this.id_leilão = id_leilão;
            this.id_licitador = id_licitador;
            this.valor = valor;
        }

        //MÉTODOS DE ACESSO AOS ATRIBUTOS//

        public int getID()
        {
            return this.id;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public int getId_leilao()
        {
            return this.id_leilão;
        }

        public void setId_leilao(int id)
        {
            this.id_leilão = id;
        }

        public int getId_Licitador()
        {
            return this.id_licitador;
        }

        public void setId_Licitador(int id)
        {
            this.id_licitador = id;
        }
        
        public decimal getValor()
        {
            return this.valor;
        }

        public void setValor(decimal v)
        {
            this.valor = v;
        }

        //OPERAÇÕES//
    }
}