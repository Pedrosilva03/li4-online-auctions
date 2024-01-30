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

                                l = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, null, null, null);
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
                cmd = "UPDATE dbo.Leilao SET id_Criador = @id_Criador, descricao = @descricao, precoReserva = @precoReserva, precoMinimo = @precoMinimo, dataHoraInicial = @dataHoraInicial, duracao = @duracao, id_lanceAtual = @id_lanceAtual WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Leilao (id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual) VALUES (@Key, @id_Criador, @descricao, @precoReserva, @precoMinimo, @dataHoraInicial, @duracao, @id_lanceAtual)";
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
                                int? id_lanceAtual = reader.IsDBNull(reader.GetOrdinal("id_lanceAtual")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("id_lanceAtual"));
                                Leilao l = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, null, null, null);
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
            string cmd = "SELECT * FROM Leilao WHERE (DATEADD(MINUTE, duracao, dataHoraInicial) >= GETDATE()) OR (dataHoraInicial > GETDATE())";
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
                                Leilao leilao = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, null, null, null);
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
                                string nome = reader.GetString(reader.GetOrdinal("nome"));
                                string condicao = reader.GetString(reader.GetOrdinal("condicao"));
                                string raridade = reader.GetString(reader.GetOrdinal("raridade"));
                                string caminhoImagem = reader.IsDBNull(reader.GetOrdinal("caminhoImagem")) ? (string?)null : reader.GetString(reader.GetOrdinal("caminhoImagem"));
                                TipoArtigo tipo = (TipoArtigo)Enum.Parse(typeof(TipoArtigo), reader.GetString(reader.GetOrdinal("tipo")));
                                Artigo artigo = new Artigo(id, id_leilao, nome, condicao, raridade, caminhoImagem, tipo);
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

        public void update_id_lanceAtual(int id_leilao, int? id_lance)
        {
            string cmd = "UPDATE dbo.Leilao SET id_lanceAtual = @id_lance WHERE id = @id_leilao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@id_leilao", id_leilao);
                        command.Parameters.AddWithValue("@id_lance", (object)id_lance ?? DBNull.Value);
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in update id_lanceAtual method: {ex.Message}");
                throw new DAOException("Erro na função update id_lanceAtual do LeilaoDAO");
            }
        }

        public void favoritar_leilao(int id_leilao, int id_utilizador) 
        {
            string cmd = "INSERT INTO dbo.LeilaoFavoritos (id_leilao, id_pessoa) VALUES (@id_leilao, @id_utilizador)";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@id_leilao", id_leilao);
                        command.Parameters.AddWithValue("@id_utilizador", id_utilizador);
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in favoritar_leilao method: {ex.Message}");
                throw new DAOException("Erro na função favoritar_leilao do LeilaoDAO");
            }
        }

        public void desfavoritar_leilao(int id_leilao, int id_utilizador) 
        {
            string cmd = "DELETE FROM dbo.LeilaoFavoritos WHERE id_leilao = @id_leilao AND id_pessoa = @id_utilizador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@id_leilao", id_leilao);
                        command.Parameters.AddWithValue("@id_utilizador", id_utilizador);
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in desfavoritar_leilao method: {ex.Message}");
                throw new DAOException("Erro na função desfavoritar_leilao do LeilaoDAO");
            }
        }

        public bool e_favorito(int id_leilao, int id_utilizador) 
        {
            bool result = false;
            string cmd = "SELECT * FROM dbo.LeilaoFavoritos WHERE id_leilao = @id_leilao AND id_pessoa = @id_utilizador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@id_leilao", id_leilao);
                        command.Parameters.AddWithValue("@id_utilizador", id_utilizador);
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in e_favorito method: {ex.Message}");
                throw new DAOException("Erro na função e_favorito do LeilaoDAO");
            }
            return result;
        }

        public List<int> ids_favoritos(int id_utilizador)
        {
            List<int> ids = new List<int>();
            string cmd = "SELECT id_leilao FROM dbo.LeilaoFavoritos WHERE id_pessoa = @id_utilizador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@id_utilizador", id_utilizador);
                        con.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ids.Add(reader.GetInt32(reader.GetOrdinal("id_leilao")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ids_favoritos method: {ex.Message}");
                throw new DAOException("Erro na função ids_favoritos do LeilaoDAO");
            }
            return ids;
        }

        public List<Leilao> get_leiloes_favoritos(List<int> ids)
        {
            List<Leilao> leiloes = new List<Leilao>();

            if (ids.Count == 0)
            {
                return leiloes;
            }

            string cmd = "SELECT * FROM dbo.Leilao WHERE id IN (";
            for (int i = 0; i < ids.Count; i++)
            {
                cmd += "@id" + i;
                if (i < ids.Count - 1)
                {
                    cmd += ",";
                }
            }
            cmd += ")";

            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            command.Parameters.AddWithValue("@id" + i, ids[i]);
                        }
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
                                Leilao leilao = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, null, null, null);
                                leiloes.Add(leilao);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in get_leiloes_favoritos method: {ex.Message}");
                throw new DAOException("Erro na função get_leiloes_favoritos do LeilaoDAO");
            }

            return leiloes;
        }


        public List<Leilao> get_leiloes_vencidos(int id_utilizador) 
        {
            List<Leilao> leiloes = new List<Leilao>();
            string cmd = "SELECT * FROM dbo.Leilao WHERE (DATEADD(MINUTE, duracao, dataHoraInicial) < GETDATE()) AND id_lanceAtual IS NOT NULL AND id_lanceAtual IN (SELECT id FROM dbo.Lance WHERE id_licitador = @id_utilizador) AND id_lanceAtual IN (SELECT id FROM dbo.Lance WHERE valor > (SELECT MAX(precoReserva) FROM dbo.Leilao WHERE id = Leilao.id))";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {   	        
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {   
                        command.Parameters.AddWithValue("@id_utilizador", id_utilizador);
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
                                Leilao leilao = new Leilao(id, id_Criador, descricao, precoReserva, precoMinimo, dataHoraInicial, duracao, id_lanceAtual, null, null, null);
                                leiloes.Add(leilao);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in get_leiloes_vencidos method: {ex.Message}");
                throw new DAOException("Erro na função get_leiloes_vencidos do LeilaoDAO");
            }
            return leiloes; 
        } 
    }
}