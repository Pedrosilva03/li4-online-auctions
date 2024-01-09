using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Leiloes;
using app.Leiloeira.Pessoas;
using app.Leiloeira.Transacoes;

namespace app.Data
{
    public interface IDatabaseFacade
    {
        //ARTIGOS//

        public bool ID_existe(int idArtigo);
        public bool Nome_existe(int idArtigo, string nome);
        public bool Cond_existe(int idArtigo, decimal condicao);
        public bool Rarid_existe(int idArtigo, string raro);
        public bool Descr_existe(int idArtigo, string descricao);
        public bool Path_existe(int idArtigo, string p);
        public bool Art_existe(Artigo a);
        public Artigo get_Artigo(int idArtigo);
        public void add_Artigo(Artigo a);
        public void remove_Artigo(int idArtigo);
        public ICollection<Artigo> get_Artigos();
        public ICollection<int> get_IDsArtigos();

        //LANCES//

        public bool IDLance_existe(int idLance);
        public bool IdLeilao_existe(int idLance, int idLeilao);
        public bool IdLicitador_existe(int idLance, int IdLicitador);
        public bool valorLance_existe(int idLance, decimal valor);
        public bool Art_existe(Lance l);
        public Lance get_Lance(int idlance);
        public void add_Lance(Lance l);
        public void remove_Lance(int idlance);
        public ICollection<Lance> get_Lances();
        public ICollection<int> get_IDsLance();

        //LEILÕES//

        public bool IDLeilao_existe(int idLeilao);
        public bool IdCriador_existe(int idLeilao, int idCriador);
        public bool PReserva_existe(int idLeilao, decimal reserva);
        public bool PMinimo_existe(int idLeilao, int minimo);
        public bool DataInicial_existe(int idLeilao, DateTime dataHoraInicial);
        public bool DataFinal_existe(int idLeilao, DateTime dataHoraFinal);
        public bool Duracao_existe(int idLeilao, int d);
        public bool IDLAtual_existe(int idLeilao, int l);
        public bool IDLFinal_existe(int idLeilao, int l);
        public bool Leilao_existe(Leilao l);
        public Leilao get_Leilao(int idLeilao);
        public void add_Leilao(Leilao l);
        public void remove_Leilao(int idLeilao);
        public ICollection<Leilao> get_Leiloes();
        public ICollection<int> get_IDsLeiloes();

        //PESSOAS//

        public bool IDPessoa_existe(int idPessoa);
        public bool TPessoa_existe(int idPessoa, TipoDePessoa t);
        public bool Email_existe(int idPessoa, string e);
        public bool Pass_existe(int idPessoa, string p);
        public bool Saldo_existe(int idPessoa, decimal saldo);
        public bool Telemovel_existe(int idPessoa, int t);
        public bool Nickname_existe(int idPessoa, string nickname);
        public bool Pessoa_existe(Pessoa p);
        public Pessoa get_Pessoa(int idPessoa);
        public void add_Pessoa(Pessoa p);
        public void remove_Pessoa(int idPessoa);
        public ICollection<Pessoa> get_Pessoas();
        public int get_num_Pessoas();
        public ICollection<int> get_IDsPessoas();
    
        //TRANSAÇÕES//

        public bool IDTransação_existe(int idTransação);
        public bool Idleilao_existe(int idTransação, int id);
        public bool IdComprador_existe(int idTransação, int id);
        public bool IdVendedor_existe(int idTransação, int id);
        public bool Data_existe(int idTransação, DateTime d);
        public bool valor_existe(int idTransação, decimal v);
        public bool Taxa_existe(int idTransação, decimal t);
        public bool Transacao_existe(Transacao t);
        public Transacao get_Transacao(int idTransação);
        public void add_Transacao(Transacao t);
        public void remove_Transacao(int idTransação);
        public ICollection<Transacao> get_Transacoes();
        public ICollection<int> get_IDsTransacoes();
    }
}