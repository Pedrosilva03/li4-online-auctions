using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Pessoas;

namespace app.Leiloeira.Transacoes
{
    public class Transacao
    {
        private int id;
        private int id_leilão;
        private Pessoa vendedor;
        private Pessoa comprador;
        private DateTime data;
        private Lance valorTransacao;
        private decimal taxa;
        private Dictionary<int, Artigo> artigosVendidos;


        //CONSTRUTORES//

        public Transacao (int id, int id_leilão, Pessoa vendedor, Pessoa comprador, DateTime data, Lance valorTransacao, decimal taxa, Dictionary<int, Artigo> artigosVendidos){
            this.id = id;
            this.id_leilão = id_leilão;
            this.vendedor = vendedor;
            this.comprador = comprador;
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

        public Pessoa getVendedor()
        {
            return this.vendedor;
        }

        public void setVendedor(Pessoa p)
        {
            this.vendedor = p;
        }

        public Pessoa getComprador()
        {
            return this.comprador;
        }

        public void setComprador(Pessoa p)
        {
            this.comprador = p;
        }

        public DateTime getData()
        {
            return this.data;
        }

        public void setData(DateTime d)
        {
            this.data = d;
        }
        
        public Lance getValor()
        {
            return this.valorTransacao;
        }

        public void setValor(Lance l)
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

        //OPERAÇÕES//
    }
}