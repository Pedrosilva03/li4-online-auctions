using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Pessoas;

namespace app.Leiloeira.Leiloes
{
    public class Leilao
    {
        private int id;
        private int id_Criador;
        private string descricao;
        private decimal precoReserva;
        private decimal precoMinimo;
        private DateTime dataHoraInicial;
        private int duracao;
        private int id_lanceAtual;
        private int id_lanceFinal;
        private Dictionary<int, Pessoa> participantes;
        private Dictionary<int, Lance> lancesFeitos;
        private Dictionary<int, Artigo> artigos;

        //CONSTRUTORES//

        public Leilao(int id, int id_Criador, string descricao, decimal precoReserva, decimal precoMinimo, DateTime dataHoraInicial, int duracao, int id_lanceAtual, int id_lanceFinal, Dictionary<int, Pessoa> participantes, Dictionary<int, Lance> lancesFeitos, Dictionary<int, Artigo> artigos)
        {
            this.id = id;
            this.id_Criador = id_Criador;
            this.descricao = descricao;
            this.precoReserva = precoReserva;
            this.precoMinimo = precoMinimo;
            this.dataHoraInicial = dataHoraInicial;
            this.duracao = duracao;
            this.id_lanceAtual = id_lanceAtual;
            this.id_lanceFinal = id_lanceFinal;
            this.participantes = participantes;
            this.lancesFeitos = lancesFeitos;
            this.artigos = artigos;
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

        public int getId_Criador()
        {
            return this.id_Criador;
        }

        public void setId_Criador (int id_Criador)
        {
            this.id_Criador = id_Criador;
        }

        public string getDescricao()
        {
            return this.descricao;
        }

        public void setDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public decimal getPrecoReserva()
        {
            return this.precoReserva;
        }

        public void setPrecoReserva(decimal p)
        {
            this.precoReserva = p;
        }
        
        public decimal getPrecoMinimo()
        {
            return this.precoMinimo;
        }

        public void setPrecoMinimo(decimal p)
        {
            this.precoMinimo = p;
        }

        public DateTime getDataHoraInicial()
        {
            return this.dataHoraInicial;
        }

        public void setDataHoraInicial(DateTime d)
        {
            this.dataHoraInicial = d;
        }

        public int getDuracao()
        {
            return this.duracao;
        }

        public void setDuracao(int t)
        {
            this.duracao = t;
        }

        public int getIdLanceAtual()
        {
            return this.id_lanceAtual;
        }

        public void setIdLanceAtual(int id)
        {
            this.id_lanceAtual = id;
        }

        public int getIdLanceFinal()
        {
            return this.id_lanceFinal;
        }

        public void setIdLanceFinal(int id)
        {
            this.id_lanceFinal = id;
        }

        public Dictionary<int, Pessoa> getParticipantes()
        {
            return this.participantes;
        }

        public void setParticipantes(Dictionary<int, Pessoa> p)
        {
            this.participantes = p;
        }

        public Dictionary<int, Lance> getLancesFeitos()
        {
            return this.lancesFeitos;
        }

        public void setLancesFeitos(Dictionary<int, Lance> l)
        {
            this.lancesFeitos = l;
        }

        public Dictionary<int, Artigo> getArtigos()
        {
            return this.artigos;
        }

        public void setArtigos(Dictionary<int, Artigo> a)
        {
            this.artigos = a;
        }
    }
}