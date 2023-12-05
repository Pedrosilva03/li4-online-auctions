using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Pessoas;

namespace app.Leiloeira.Leiloes
{
    public class Leilao
    {
        private int id;
        private int id_Criador;
        private decimal precoReserva;
        private decimal precoMinimo;
        private DateTime dataHoraInicial;
        private DateTime dataHoraFinal;
        private TimeOnly duracao;
        private Lance lanceAtual;
        private Lance lanceFinal;
        private Dictionary<int, Pessoa> participantes;
        private Dictionary<int, Lance> lancesFeitos;
        private Dictionary<int, Artigo> artigos;

        //CONSTRUTORES//

        public Leilao(int id, int id_Criador, decimal precoReserva, decimal precoMinimo, DateTime dataHoraInicial, DateTime dataHoraFinal, TimeOnly duracao, Lance lanceAtual, Lance lanceFinal, Dictionary<int, Pessoa> participantes, Dictionary<int, Lance> lancesFeitos, Dictionary<int, Artigo> artigos)
        {
            this.id = id;
            this.id_Criador = id_Criador;
            this.precoReserva = precoReserva;
            this.precoMinimo = precoMinimo;
            this.dataHoraInicial = dataHoraInicial;
            this.dataHoraFinal = dataHoraFinal;
            this.duracao = duracao;
            this.lanceAtual = lanceAtual;
            this.lanceFinal = lanceFinal;
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

        public DateTime getDataHoraFinal()
        {
            return this.dataHoraFinal;
        }

        public void setDataHoraFinal(DateTime d)
        {
            this.dataHoraFinal = d;
        }

        public TimeOnly getDuracao()
        {
            return this.duracao;
        }

        public void setDuracao(TimeOnly t)
        {
            this.duracao = t;
        }

        public Lance getLanceAtual()
        {
            return this.lanceAtual;
        }

        public void setLanceAtual(Lance l)
        {
            this.lanceAtual = l;
        }

        public Lance getLanceFinal()
        {
            return this.lanceFinal;
        }

        public void setLanceFinal(Lance l)
        {
            this.lanceFinal = l;
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

        //OPERAÇÕES//
    }
}