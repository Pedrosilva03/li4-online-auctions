namespace app.Leiloeira.Artigos
{
    public class Artigo
    {
        private int id;
        private int id_leilão;
        private int id_transacao;
        private string nome;
        private decimal condicao;
        private string raridade;
        private string descricao;
        private string caminhoImagem;
        private TipoArtigo tipo;


        //CONSTRUTORES//

        public Artigo (int id, int id_leilão, int id_transacao, string nome, decimal condicao, string raridade, string descricao, string caminhoImagem, TipoArtigo tipo){
            this.id = id;
            this.id_leilão = id_leilão;
            this.id_transacao = id_transacao;
            this.nome = nome;
            this.condicao = condicao;
            this.raridade = raridade;
            this.descricao = descricao;
            this.caminhoImagem = caminhoImagem;
            this.tipo = tipo;
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

        public int getId_Transacao()
        {
            return this.id_transacao;
        }

        public void setId_Transacao(int id)
        {
            this.id_transacao = id;
        }

        public string getNome()
        {
            return this.nome;
        }

        public void setNome(string n)
        {
            this.nome = n;
        }

        public decimal getCondicao()
        {
            return this.condicao;
        }

        public void setCondicao(decimal c)
        {
            this.condicao = c;
        }
        
        public string getRaridade()
        {
            return this.raridade;
        }

        public void setRaridade(string r)
        {
            this.raridade = r;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public void setDescricao(string d)
        {
            this.descricao = d;
        }

        public string getCaminhoImagem()
        {
            return this.caminhoImagem;
        }

        public void setCaminhoImagem(string c)
        {
            this.caminhoImagem = c;
        }

        public TipoArtigo getTipo()
        {
            return this.tipo;
        }

        public void setTipo(TipoArtigo t)
        {
            this.tipo = t;
        }
    }
}