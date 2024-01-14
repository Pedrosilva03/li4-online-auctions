using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Leiloes;
using app.Leiloeira.Pessoas;
using app.Leiloeira.Transacoes;

namespace app.Data
{
    public class DatabaseFacade : IDatabaseFacade
    {
        private ArtigoDAO artigoDAO;
        private LanceDAO lanceDAO;
        private LeilaoDAO leilaoDAO;
        private TransacaoDAO transacaoDAO;
        private PessoaDAO pessoaDAO;

        public DatabaseFacade() 
        { 
            this.artigoDAO = ArtigoDAO.getInstance();
            this.lanceDAO = LanceDAO.getInstance();
            this.transacaoDAO = TransacaoDAO.getInstance();
            this.leilaoDAO = LeilaoDAO.getInstance();
            this.pessoaDAO = PessoaDAO.getInstance();
        }

        //ARTIGOS//

        public bool ID_existe(int idArtigo){
            return this.artigoDAO.containsKey(idArtigo);
        }

        public bool Nome_existe(int idArtigo, string nome){
            return this.artigoDAO.get(idArtigo).getNome() == nome;
        }

        public bool Cond_existe(int idArtigo, string condicao){
            return this.artigoDAO.get(idArtigo).getCondicao() == condicao;
        }

        public bool Rarid_existe(int idArtigo, string raro){
            return this.artigoDAO.get(idArtigo).getRaridade() == raro;
        }

        public bool Path_existe(int idArtigo, string p){
            return this.artigoDAO.get(idArtigo).getCaminhoImagem() == p;
        }

        public bool Art_existe(Artigo a)
        {
            return this.artigoDAO.containsValue(a);
        }

        public Artigo get_Artigo(int idArtigo)
        {
            return this.artigoDAO.get(idArtigo);
        }

        public void add_Artigo(Artigo a)
        {
            this.artigoDAO.put(a.getID(), a);
        }

        public void remove_Artigo(int idArtigo)
        {
            this.artigoDAO.remove(idArtigo);
        }

        public ICollection<Artigo> get_Artigos()
        {
            return this.artigoDAO.values();
        }

        public ICollection<int> get_IDsArtigos()
        {
            return this.artigoDAO.keys();
        }

        //LANCES//

        public bool IDLance_existe(int idLance){
            return this.lanceDAO.containsKey(idLance);
        }

        public bool IdLeilao_existe(int idLance, int idLeilao){
            return this.lanceDAO.get(idLance).getId_leilao() == idLeilao;
        }

        public bool IdLicitador_existe(int idLance, int IdLicitador){
            return this.lanceDAO.get(idLance).getId_Licitador() == IdLicitador;
        }

        public bool valorLance_existe(int idLance, decimal valor){
            return this.lanceDAO.get(idLance).getValor() == valor;
        }

        public bool Art_existe(Lance l)
        {
            return this.lanceDAO.containsValue(l);
        }

        public Lance get_Lance(int idlance)
        {
            return this.lanceDAO.get(idlance);
        }

        public void add_Lance(Lance l)
        {
            this.lanceDAO.put(l.getID(), l);
        }

        public void remove_Lance(int idlance)
        {
            this.lanceDAO.remove(idlance);
        }

        public ICollection<Lance> get_Lances()
        {
            return this.lanceDAO.values();
        }

        public ICollection<int> get_IDsLance()
        {
            return this.lanceDAO.keys();
        }

        //LEILÕES//

        public bool IDLeilao_existe(int idLeilao){
            return this.leilaoDAO.containsKey(idLeilao);
        }

        public bool IdCriador_existe(int idLeilao, int idCriador){
            return this.leilaoDAO.get(idLeilao).getId_Criador() == idCriador;
        }

        public bool Descricao_existe(int idLeilao, string descricao){
            return this.leilaoDAO.get(idLeilao).getDescricao() == descricao;
        }

        public bool PReserva_existe(int idLeilao, decimal reserva){
            return this.leilaoDAO.get(idLeilao).getPrecoReserva() == reserva;
        }

        public bool PMinimo_existe(int idLeilao, decimal minimo){
            return this.leilaoDAO.get(idLeilao).getPrecoMinimo() == minimo;
        }

        public bool DataInicial_existe(int idLeilao, DateTime dataHoraInicial){
            return this.leilaoDAO.get(idLeilao).getDataHoraInicial().Equals(dataHoraInicial);
        }

        public bool Duracao_existe(int idLeilao, int d){
            return this.leilaoDAO.get(idLeilao).getDuracao() == d;
        }

        public bool IDLAtual_existe(int idLeilao, int l){
            return this.leilaoDAO.get(idLeilao).getIdLanceAtual() == l;
        }

        public bool IDLFinal_existe(int idLeilao, int l){
            return this.leilaoDAO.get(idLeilao).getIdLanceFinal() == l;
        }
        public bool Leilao_existe(Leilao l)
        {
            return this.leilaoDAO.containsValue(l);
        }

        public Leilao get_Leilao(int idLeilao)
        {
            return this.leilaoDAO.get(idLeilao);
        }

        public void add_Leilao(Leilao l)
        {
            this.leilaoDAO.put(l.getID(), l);
        }

        public void remove_Leilao(int idLeilao)
        {
            this.leilaoDAO.remove(idLeilao);
        }

        public ICollection<Leilao> get_Leiloes()
        {
            return this.leilaoDAO.values();
        }

        public ICollection<int> get_IDsLeiloes()
        {
            return this.leilaoDAO.keys();
        }

        //PESSOAS//

        public bool IDPessoa_existe(int idPessoa){
            return this.pessoaDAO.containsKey(idPessoa);
        }

        public bool TPessoa_existe(int idPessoa, TipoDePessoa t){
            return this.pessoaDAO.get(idPessoa).getTipo() == t;
        }

        public bool Email_existe(int idPessoa, string e){
            return this.pessoaDAO.get(idPessoa).getEmail() == e;
        }

        public bool Pass_existe(int idPessoa, string p){
            return this.pessoaDAO.get(idPessoa).getPassword() == p;
        }

        public bool Saldo_existe(int idPessoa, decimal saldo){
            return this.pessoaDAO.get(idPessoa).getSaldo() == saldo;
        }

        public bool Telemovel_existe(int idPessoa, int t){
            return this.pessoaDAO.get(idPessoa).getTelemovel() == t;
        }

        public bool Nickname_existe(int idPessoa, string nickname){
            return this.pessoaDAO.get(idPessoa).getNickname() == nickname;
        }

        public bool Pessoa_existe(Pessoa p)
        {
            return this.pessoaDAO.containsValue(p);
        }

        public Pessoa get_Pessoa(int idPessoa)
        {
            return this.pessoaDAO.get(idPessoa);
        }

        public void add_Pessoa(Pessoa p)
        {
            this.pessoaDAO.put(p.getID(), p);
        }

        public void remove_Pessoa(int idPessoa)
        {
            this.pessoaDAO.remove(idPessoa);
        }

        public ICollection<Pessoa> get_Pessoas()
        {
            return this.pessoaDAO.values();
        }

        public int get_num_Pessoas()
        {
            return this.pessoaDAO.size();
        }

        public ICollection<int> get_IDsPessoas()
        {
            return this.pessoaDAO.keys();
        }
    
        //TRANSAÇÕES//

        public bool IDTransação_existe(int idTransação){
            return this.transacaoDAO.containsKey(idTransação);
        }

        public bool Idleilao_existe(int idTransação, int id){
            return this.transacaoDAO.get(idTransação).getId_leilao() == id;
        }

        public bool IdComprador_existe(int idTransação, int id){
            return this.transacaoDAO.get(idTransação).getComprador() == id;
        }

        public bool IdVendedor_existe(int idTransação, int id){
            return this.transacaoDAO.get(idTransação).getVendedor() == id;
        }

        public bool Data_existe(int idTransação, DateTime d){
            return this.transacaoDAO.get(idTransação).getData().Equals(d);
        }

        public bool valor_existe(int idTransação, decimal v){
            return this.transacaoDAO.get(idTransação).getValor() == v;
        }

        public bool Taxa_existe(int idTransação, decimal t){
            return this.transacaoDAO.get(idTransação).getTaxa() == t;
        }

        public bool Transacao_existe(Transacao t)
        {
            return this.transacaoDAO.containsValue(t);
        }

        public Transacao get_Transacao(int idTransação)
        {
            return this.transacaoDAO.get(idTransação);
        }

        public void add_Transacao(Transacao t)
        {
            this.transacaoDAO.put(t.getID(), t);
        }

        public void remove_Transacao(int idTransação)
        {
            this.transacaoDAO.remove(idTransação);
        }

        public ICollection<Transacao> get_Transacoes()
        {
            return this.transacaoDAO.values();
        }

        public ICollection<int> get_IDsTransacoes()
        {
            return this.transacaoDAO.keys();
        }
    }
}