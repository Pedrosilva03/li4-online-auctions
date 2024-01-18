using System.Data.SqlClient;
using app.Leiloeira.Leiloes;
using app.Leiloeira.Artigos;

namespace app.Data
{
    public class LeilaoDAO
    {
        private static LeilaoDAO? singleton = null;

        private LeilaoDAO() { }

        public static LeilaoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new LeilaoDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string cmd1 = "SELECT * FROM dbo.Leilao WHERE id = @Key";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(cmd1, con))
                    {
                        cmd.Parameters.AddWithValue("@Key", key);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no containsKey do LeilaoDAO");
            }
            return result;
        }

        public bool containsValue(Leilao value)
        {
            return containsKey(value.getID());
        }
        
        public Leilao get(int key)
        {
            Leilao? l = null;
            string cmd1 = $"SELECT * FROM dbo.Leilao where id = @Key";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(cmd1, con))
                    {
                        cmd.Parameters.AddWithValue("@Key", key);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                int id_Criador = reader.GetInt32(reader.GetOrdinal("id_Criador"));
                                string descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                decimal precoReserva = reader.GetDecimal(reader.GetOrdinal("precoReserva"));
                                decimal precoMinimo = reader.GetDecimal(reader.GetOrdinal("precoMinimo"));
                                DateTime dataHoraInicial = reader.GetDateTime(reader.GetOrdinal("dataHoraInicial"));
                                int duracao = reader.GetInt32(reader.GetOrdinal("duracao"));
                                int? id_lanceAtual = reader.IsDBNull(reader.GetOrdinal("id_lanceAtual")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id_lanceAtual"));
                                int? id_lanceFinal = reader.IsDBNull(reader.GetOrdinal("id_lanceFinal")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id_lanceFinal"));

                                l = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, id_lanceFinal, null, null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in get method: {ex.Message}");
                throw new DAOException("Erro no get do LeilaoDAO");
            }
            return l;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new List<int>();
            string cmd = "SELECT id FROM dbo.Leilao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                keys.Add(reader.GetInt32(reader.GetOrdinal("id")));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no keys do ArtigoDAO");
            }
            return keys;
        }

        public void put(int key, Leilao value)
        {
            string cmd;
            if (containsKey(key))
            {
                cmd = "UPDATE dbo.Leilao SET id_Criador = @id_Criador, descricao = @descricao, precoReserva = @precoReserva, precoMinimo = @precoMinimo, dataHoraInicial = @dataHoraInicial, duracao = @duracao, id_lanceAtual = @id_lanceAtual, id_lanceFinal = @id_lanceFinal WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Leilao (id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, id_lanceFinal) VALUES (@Key, @id_Criador, @descricao, @precoReserva, @precoMinimo, @dataHoraInicial, @duracao, @id_lanceAtual, @id_lanceFinal)";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", key);
                        command.Parameters.AddWithValue("@id_Criador", value.getId_Criador());
                        command.Parameters.AddWithValue("@descricao", value.getDescricao());
                        command.Parameters.AddWithValue("@precoReserva", value.getPrecoReserva());
                        command.Parameters.AddWithValue("@precoMinimo", value.getPrecoMinimo());
                        command.Parameters.AddWithValue("@dataHoraInicial", value.getDataHoraInicial());
                        command.Parameters.AddWithValue("@duracao", value.getDuracao());
                        command.Parameters.AddWithValue("@id_lanceAtual", (object)value.getIdLanceAtual() ?? DBNull.Value);
                        command.Parameters.AddWithValue("@id_lanceFinal", (object)value.getIdLanceFinal() ?? DBNull.Value);

                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new DAOException("Erro no put do LeilaoDAO");
            }
        }

        public Leilao remove(int key)
        {
            Leilao? l = get(key);
            if (l != null)
            {
                string cmd = "DELETE FROM dbo.Leilao WHERE id = @Key";

                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        using (SqlCommand command = new SqlCommand(cmd, con))
                        {
                            command.Parameters.AddWithValue("@Key", key);

                            con.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no remove do LeilaoDAO");
                }
            }
            return l;
        }

        public int size()
        {
            int count = 0;
            string cmd = "SELECT COUNT(*) FROM dbo.Leilao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        con.Open();
                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no size do LeilaoDAO");
            }
            return count;
        }

        public ICollection<Leilao> values()
        {
            ICollection<Leilao> leiloes = new List<Leilao>(); 
            string cmd = "SELECT * FROM dbo.Leilao"; 
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                int id_Criador = reader.GetInt32(reader.GetOrdinal("id_Criador"));
                                string descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                decimal precoReserva = reader.GetDecimal(reader.GetOrdinal("precoReserva"));
                                decimal precoMinimo = reader.GetDecimal(reader.GetOrdinal("precoMinimo"));
                                DateTime dataHoraInicial = reader.GetDateTime(reader.GetOrdinal("dataHoraInicial"));
                                int duracao = reader.GetInt32(reader.GetOrdinal("duracao"));
                                int id_lanceAtual = reader.GetInt32(reader.GetOrdinal("id_lanceAtual"));
                                int id_lanceFinal = reader.GetInt32(reader.GetOrdinal("id_lanceFinal"));
                                /* TODO: DICIONÁRIOS (???) dataRowDictionary = Enumerable.Range(0, reader.FieldCount).ToDictionary(i => reader.GetName(i), i=> reader.GetValue(i).ToString());*/
                                Leilao l = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, id_lanceFinal, null, null, null);
                                leiloes.Add(l);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do LeilaoDAO");
            }
            return leiloes;
        }

        public ICollection<Leilao> leiloes_nao_acabados()
        {
            ICollection<Leilao> leiloesNaoAcabados = new List<Leilao>();
            string cmd = "SELECT * FROM Leilao WHERE GETDATE() < dataHoraInicial";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read()) 
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                int id_Criador = reader.GetInt32(reader.GetOrdinal("id_Criador"));
                                string descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                decimal precoReserva = reader.GetDecimal(reader.GetOrdinal("precoReserva"));
                                decimal precoMinimo = reader.GetDecimal(reader.GetOrdinal("precoMinimo"));
                                DateTime dataHoraInicial = reader.GetDateTime(reader.GetOrdinal("dataHoraInicial"));
                                int duracao = reader.GetInt32(reader.GetOrdinal("duracao"));
                                int? id_lanceAtual = reader.IsDBNull(reader.GetOrdinal("id_lanceAtual")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id_lanceAtual"));
                                int? id_lanceFinal = reader.IsDBNull(reader.GetOrdinal("id_lanceFinal")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id_lanceFinal"));
                                Leilao leilao = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, id_lanceFinal, null, null, null);
                                leiloesNaoAcabados.Add(leilao);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in leiloes_nao_acabados method: {ex.Message}");
                throw new DAOException("Erro na função leiloes_nao_acabados do LeilaoDAO");
            }
            return leiloesNaoAcabados;
        }

        public List<Artigo> artigos_leilao(int key)
        {
            List<Artigo> artigos = new List<Artigo>();
            string cmd = "SELECT * FROM dbo.Artigo WHERE id_leilao = @Key";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@Key", key);
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                int id_leilao = reader.GetInt32(reader.GetOrdinal("id_leilao"));
                                int? id_transacao = reader.IsDBNull(reader.GetOrdinal("id_transacao")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id_transacao"));
                                string nome = reader.GetString(reader.GetOrdinal("nome"));
                                string condicao = reader.GetString(reader.GetOrdinal("condicao"));
                                string raridade = reader.GetString(reader.GetOrdinal("raridade"));
                                int caminhoImagemOrdinal = reader.GetOrdinal("caminhoImagem");
                                byte[] caminhoImagem = null;

                                if (!reader.IsDBNull(caminhoImagemOrdinal)) {
                                    long bufferSize = reader.GetBytes(caminhoImagemOrdinal, 0, null, 0, 0);
                                    caminhoImagem = new byte[bufferSize];
                                    reader.GetBytes(caminhoImagemOrdinal, 0, caminhoImagem, 0, (int)bufferSize);
                                }
                                
                                TipoArtigo tipo = (TipoArtigo)Enum.Parse(typeof(TipoArtigo), reader.GetString(reader.GetOrdinal("tipo")));

                                Artigo artigo = new Artigo(id, id_leilao, id_transacao, nome, condicao, raridade, caminhoImagem, tipo);
                                artigos.Add(artigo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in artigos_leilao method: {ex.Message}");
                throw new DAOException("Erro na função artigos_leilao do LeilaoDAO");
            }
            return artigos;
        }
    }
}