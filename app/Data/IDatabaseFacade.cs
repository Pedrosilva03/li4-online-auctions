using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Leiloes;
using app.Leiloeira.Pessoas;

namespace app.Data
{
    public interface IDatabaseFacade
    {
        //ARTIGOS//

        public bool ID_existe(int idArtigo);
        public bool Nome_existe(int idArtigo, string nome);
        public bool Cond_existe(int idArtigo, string condicao);
        public bool Rarid_existe(int idArtigo, string raro);
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
        public Lance get_Lance(int? idlance);
        public void add_Lance(Lance l);
        public void remove_Lance(int idlance);
        public ICollection<Lance> get_Lances();
        public ICollection<int> get_IDsLance();

        //LEILÕES//

        public bool IDLeilao_existe(int idLeilao);
        public bool IdCriador_existe(int idLeilao, int idCriador);
        public bool Descricao_existe(int idLeilao, string descricao);
        public bool PReserva_existe(int idLeilao, decimal reserva);
        public bool PMinimo_existe(int idLeilao, decimal minimo);
        public bool DataInicial_existe(int idLeilao, DateTime dataHoraInicial);
        public bool Duracao_existe(int idLeilao, int d);
        public bool IDLAtual_existe(int idLeilao, int l);
        public bool Leilao_existe(Leilao l);
        public Leilao get_Leilao(int idLeilao);
        public void add_Leilao(Leilao l);
        public void remove_Leilao(int idLeilao);
        public ICollection<Leilao> get_Leiloes();
        public ICollection<int> get_IDsLeiloes();

        public ICollection<Leilao> get_leiloes_nao_acabados();

        public List<Artigo> get_artigos_leilao(int idLeilao);

        public void update_id_lanceAtual(int id_leilao, int id_lance);

        public void favoritar_leilao(int id_leilao, int id_utilizador);

        public void desfavoritar_leilao(int id_leilao, int id_utilizador);

        public bool e_favorito(int id_leilao, int id_utilizador);

        public List<int> ids_favoritos(int id_utilizador);

        public List<Leilao> get_leiloes_favoritos(List<int> ids_favoritos);

        public List<Leilao> get_leiloes_vencidos(int id_utilizador);

        //PESSOAS//

        public bool IDPessoa_existe(int idPessoa);
        public bool TPessoa_existe(int idPessoa, TipoDePessoa t);
        public bool Email_existe(int idPessoa, string e);
        public bool Pass_existe(int idPessoa, string p);
        public bool Saldo_existe(int idPessoa, decimal? saldo);
        public bool Telemovel_existe(int idPessoa, int? t);
        public bool Nickname_existe(int idPessoa, string nickname);
        public bool Pessoa_existe(Pessoa p);
        public Pessoa get_Pessoa(int idPessoa);
        public void add_Pessoa(Pessoa p);
        public void remove_Pessoa(int idPessoa);
        public ICollection<Pessoa> get_Pessoas();
        public int get_num_Pessoas();
        public ICollection<int> get_IDsPessoas();

        public void update_saldo(int idPessoa, decimal? saldo);

        public void devolve_dinheiro_utilizador(int id_utilizador, decimal valor);

        public decimal get_saldo(int id_utilizador);
    }
}