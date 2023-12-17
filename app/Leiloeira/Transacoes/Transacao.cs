using app.Leiloeira.Artigos;

namespace app.Leiloeira.Transacoes
{
    public class Transacao
    {
        private int id;
        private int id_leilão;
        private int id_vendedor;
        private int id_comprador;
        private DateTime data;
        private decimal valorTransacao;
        private decimal taxa;
        private Dictionary<int, Artigo> artigosVendidos;


        //CONSTRUTORES//

        public Transacao (int id, int id_leilão, int id_vendedor, int id_comprador, DateTime data, decimal valorTransacao, decimal taxa, Dictionary<int, Artigo> artigosVendidos){
            this.id = id;
            this.id_leilão = id_leilão;
            this.id_vendedor = id_vendedor;
            this.id_comprador = id_comprador;
            this.data = data;
            this.valorTransacao = valorTransacao;
            this.taxa = taxa;
            this.artigosVendidos = artigosVendidos;
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

        public int getVendedor()
        {
            return this.id_vendedor;
        }

        public void setVendedor(int p)
        {
            this.id_vendedor = p;
        }

        public int getComprador()
        {
            return this.id_comprador;
        }

        public void setComprador(int p)
        {
            this.id_comprador = p;
        }

        public DateTime getData()
        {
            return this.data;
        }

        public void setData(DateTime d)
        {
            this.data = d;
        }
        
        public decimal getValor()
        {
            return this.valorTransacao;
        }

        public void setValor(decimal l)
        {
            this.valorTransacao = l;
        }

        public decimal getTaxa()
        {
            return this.taxa;
        }

        public void setTaxa (decimal t)
        {
            this.taxa = t;
        }

        public Dictionary<int, Artigo> getArtigosVendidos()
        {
            return this.artigosVendidos;
        }

        public void setArtigosVendidos(Dictionary<int, Artigo> vendidos)
        {
            this.artigosVendidos = vendidos;
        }
    }
}