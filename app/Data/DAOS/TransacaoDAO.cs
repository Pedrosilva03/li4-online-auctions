using System.Data.SqlClient;
using app.Leiloeira.Transacoes;

namespace app.Data
{
    public class TransacaoDAO
    {
        private static TransacaoDAO? singleton = null;

        private TransacaoDAO() { }

        public static TransacaoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new TransacaoDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string cmd1 = "SELECT * FROM dbo.Transacao WHERE id = @Key";
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
                throw new DAOException("Erro no containsKey do TransacaoDAO");
            }
            return result;
        }

        public bool containsValue(Transacao value)
        {
            return containsKey(value.getID());
        }
        
        public Transacao get(int key)
        {
            Transacao? t = null;
            string cmd1 = $"SELECT * FROM dbo.Transacao where id = @Key";
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
                                int id_leilão = reader.GetInt32(reader.GetOrdinal("id_leilão"));
                                int id_vendedor = reader.GetInt32(reader.GetOrdinal("id_vendedor"));
                                int id_comprador = reader.GetInt32(reader.GetOrdinal("id_comprador"));
                                DateTime data = reader.GetDateTime(reader.GetOrdinal("data"));
                                decimal valorTransacao = reader.GetDecimal(reader.GetOrdinal("valorTransacao"));
                                decimal taxa = reader.GetDecimal(reader.GetOrdinal("taxa"));

                                t = new Transacao(id, id_leilão, id_vendedor, id_comprador, data, valorTransacao, taxa, null);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do TransacaoDAO");
            }
            return t;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new List<int>();
            string cmd = "SELECT id FROM dbo.Transacao";
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
                throw new DAOException("Erro no keys do TransacaoDAO");
            }
            return keys;
        }

        public void put(int key, Transacao value)
        {
            string cmd;
            if (containsKey(key))
            {
                cmd = "UPDATE dbo.Transacao SET id = @key, id_leilão = @id_leilão, id_vendedor = @id_vendedor, id_comprador = @id_comprador, data = @data, valorTransacao = @valorTransacao, taxa = @taxa WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Transacao (id, id_leilão, id_vendedor, id_comprador, data, valorTransacao, taxa) VALUES (@Key, @id_leilão, @id_vendedor, @id_comprador, @data, @valorTransacao, @taxa)";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", key);
                        command.Parameters.AddWithValue("@id_leilão", value.getId_leilao());
                        command.Parameters.AddWithValue("@id_vendedor", value.getVendedor());
                        command.Parameters.AddWithValue("@id_comprador", value.getComprador());
                        command.Parameters.AddWithValue("@data", value.getData());
                        command.Parameters.AddWithValue("@valorTransacao", value.getValor());
                        command.Parameters.AddWithValue("@taxa", value.getTaxa());
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do TransacaoDAO");
            }
        }

        public Transacao remove(int key)
        {
            Transacao? t = get(key);
            if (t != null)
            {
                string cmd = "DELETE FROM dbo.Transacao WHERE id = @Key";

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
                    throw new DAOException("Erro no remove do TransacaoDAO");
                }
            }
            return t;
        }

        public int size()
        {
            int count = 0;
            string cmd = "SELECT COUNT(*) FROM dbo.Transacao";
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
                throw new DAOException("Erro no size do TransacaoDAO");
            }
            return count;
        }

        public ICollection<Transacao> values()
        {
            ICollection<Transacao> transacoes = new List<Transacao>(); 
            string cmd = "SELECT * FROM dbo.Transacao"; 
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
                                Transacao t = new Transacao(
                                    reader.GetInt32(0), 
                                    reader.GetInt32(1), 
                                    reader.GetInt32(2),
                                    reader.GetInt32(3), 
                                    reader.GetDateTime(4),
                                    reader.GetDecimal(5),
                                    reader.GetDecimal(8),
                                    null
                                );
                                transacoes.Add(t);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do TransacaoDAO");
            }
            return transacoes;
        }
    }
}