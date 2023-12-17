using System.Data.SqlClient;
using app.Leiloeira.Artigos;

namespace app.Data
{
    public class ArtigoDAO
    {
        private static ArtigoDAO? singleton = null;

        private ArtigoDAO() { }

        public static ArtigoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new ArtigoDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string cmd1 = "SELECT * FROM dbo.Artigo WHERE id = @Key";
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
                throw new DAOException("Erro no containsKey do ArtigoDAO");
            }
            return result;
        }

        public bool containsValue(Artigo value)
        {
            return containsKey(value.getID());
        }
        
        public Artigo get(int key)
        {
            Artigo? a = null;
            string cmd1 = $"SELECT * FROM dbo.Artigo where id = @Key";
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
                                // Construir um objeto Artigo com base nos dados lidos do banco de dados
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                int id_leilao = reader.GetInt32(reader.GetOrdinal("id_leilao"));
                                int id_transacao = reader.GetInt32(reader.GetOrdinal("id_transacao"));
                                string nome = reader.GetString(reader.GetOrdinal("nome"));
                                decimal condicao = reader.GetDecimal(reader.GetOrdinal("condicao"));
                                string raridade = reader.GetString(reader.GetOrdinal("raridade"));
                                string descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                string caminhoImagem = reader.GetString(reader.GetOrdinal("caminhoImagem"));
                                TipoArtigo tipo = (TipoArtigo)Enum.Parse(typeof(TipoArtigo), reader.GetString(reader.GetOrdinal("tipo")));


                                a = new Artigo(id, id_leilao, id_transacao, nome, condicao, raridade, descricao, caminhoImagem, tipo);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do ArtigoDAO");
            }
            return a;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new List<int>();
            string cmd = "SELECT id FROM dbo.Artigo";
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

        public void put(int key, Artigo value)
        {
            string cmd;
            if (containsKey(key))
            {
                cmd = "UPDATE dbo.Artigo SET id_leilao = @id_leilao, id_transacao = @id_transacao, nome = @nome, condicao = @condicao, raridade = @raridade, descricao = @descricao, caminhoImagem = @caminhoImagem, tipo = @tipo WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Artigo (id, id_leilao, id_transacao,  nome, condicao, raridade, descricao, caminhoImagem, tipo) VALUES (@Key, @nome, @id_leilao, @id_transacao, @condicao, @raridade, @descricao, @caminhoImagem, @tipo)";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", key);
                        command.Parameters.AddWithValue("@id_leilao", value.getId_leilao());
                        command.Parameters.AddWithValue("@id_transacao", value.getId_Transacao());
                        command.Parameters.AddWithValue("@nome", value.getNome());
                        command.Parameters.AddWithValue("@condicao", value.getCondicao());
                        command.Parameters.AddWithValue("@raridade", value.getRaridade());
                        command.Parameters.AddWithValue("@descricao", value.getDescricao());
                        command.Parameters.AddWithValue("@caminhoImagem", value.getCaminhoImagem());
                        command.Parameters.AddWithValue("@tipo", value.getTipo());

                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do ArtigoDAO");
            }
        }

        public Artigo remove(int key)
        {
            Artigo? artigoRemovido = get(key);
            if (artigoRemovido != null)
            {
                string cmd = "DELETE FROM dbo.Artigo WHERE id = @Key";

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
                    throw new DAOException("Erro no remove do ArtigoDAO");
                }
            }
            return artigoRemovido;
        }

        public int size()
        {
            int count = 0;
            string cmd = "SELECT COUNT(*) FROM dbo.Artigo";
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
                throw new DAOException("Erro no size do ArtigoDAO");
            }
            return count;
        }

        public ICollection<Artigo> values()
        {
            ICollection<Artigo> artigos = new List<Artigo>(); // Cria uma coleção para armazenar os artigos
            string cmd = "SELECT * FROM dbo.Artigo"; // Comando SQL para selecionar todos os registros da tabela Artigo
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
                                Artigo artigo = new Artigo(
                                    reader.GetInt32(0), 
                                    reader.GetInt32(1), 
                                    reader.GetInt32(2),
                                    reader.GetString(3), 
                                    reader.GetDecimal(4),
                                    reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetString(7),
                                    (TipoArtigo)Enum.Parse(typeof(TipoArtigo), reader.GetString(8))
                                );
                                artigos.Add(artigo);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do ArtigoDAO");
            }
            return artigos;
        }
    }
}