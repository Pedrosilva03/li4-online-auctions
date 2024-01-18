namespace app.Leiloeira.Artigos
{
    public class Artigo
    {
        private int id;
        private int id_leilão;
        private int? id_transacao;
        private string nome;
        private string condicao;
        private string raridade;
        private byte[] imagem;
        private TipoArtigo tipo;


        //CONSTRUTORES//

        public Artigo (int id, int id_leilão, int? id_transacao, string nome, string condicao, string raridade, byte[] imagem, TipoArtigo tipo){
            this.id = id;
            this.id_leilão = id_leilão;
            this.id_transacao = id_transacao;
            this.nome = nome;
            this.condicao = condicao;
            this.raridade = raridade;
            this.imagem = imagem;
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

        public int? getId_Transacao()
        {
            return this.id_transacao;
        }

        public void setId_Transacao(int? id)
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

        public string getCondicao()
        {
            return this.condicao;
        }

        public void setCondicao(string c)
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

        public byte[] getImagem()
        {
            return this.imagem;
        }

        public void setImagem(byte[] img)
        {
            this.imagem = img;
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