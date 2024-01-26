using System.Data.SqlClient;
using app.Leiloeira.Lances;

namespace app.Data
{
    public class LanceDAO
    {
        private static LanceDAO? singleton = null;

        private LanceDAO() { }

        public static LanceDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new LanceDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string cmd1 = "SELECT * FROM dbo.Lance WHERE id = @Key";
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
                throw new DAOException("Erro no containsKey do LanceDAO");
            }
            return result;
        }

        public bool containsValue(Lance value)
        {
            return containsKey(value.getID());
        }
        
        public Lance get(int? key)
        {
            Lance? l = null;
            string cmd1 = $"SELECT * FROM dbo.Lance where id = @Key";
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
                                int id_leilao = reader.GetInt32(reader.GetOrdinal("id_leilao"));
                                int id_licitador = reader.GetInt32(reader.GetOrdinal("id_licitador"));
                                decimal valor = reader.GetDecimal(reader.GetOrdinal("valor"));

                                l = new Lance(id, id_leilao, id_licitador, valor);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do LanceDAO");
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
            string cmd = "SELECT id FROM dbo.Lance";
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
                throw new DAOException("Erro no keys do LanceDAO");
            }
            return keys;
        }

        public void put(int key, Lance value)
        {
            string cmd;
            if (containsKey(key))
            {
                cmd = "UPDATE dbo.Lance SET id = @key, id_leilao = @id_leilao, id_licitador = @id_licitador, valor = @valor WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Lance (id, id_leilao, id_licitador, valor) VALUES (@Key, @id_leilao, @id_licitador, @valor)";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", key);
                        command.Parameters.AddWithValue("@id_leilao", value.getId_leilao());
                        command.Parameters.AddWithValue("@id_licitador", value.getId_Licitador());
                        command.Parameters.AddWithValue("@valor", value.getValor());

                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do LanceDAO");
            }
        }

        public Lance remove(int key)
        {
            Lance? lanceRemov = get(key);
            if (lanceRemov != null)
            {
                string cmd = "DELETE FROM dbo.Lance WHERE id = @Key";

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
                    throw new DAOException("Erro no remove do LanceDAO");
                }
            }
            return lanceRemov;
        }

        public int size()
        {
            int count = 0;
            string cmd = "SELECT COUNT(*) FROM dbo.Lance";
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
                throw new DAOException("Erro no size do LanceDAO");
            }
            return count;
        }

        public ICollection<Lance> values()
        {
            ICollection<Lance> lances = new List<Lance>();
            string cmd = "SELECT * FROM dbo.Lance";
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
                                int id_leilao = reader.GetInt32(reader.GetOrdinal("id_leilao"));
                                int id_licitador = reader.GetInt32(reader.GetOrdinal("id_licitador"));
                                decimal valor = reader.GetDecimal(reader.GetOrdinal("valor"));
                                Lance l = new Lance(id, id_leilao, id_licitador, valor);
                                lances.Add(l);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no values do LanceDAO");
            }
            return lances;
        }
    }
}