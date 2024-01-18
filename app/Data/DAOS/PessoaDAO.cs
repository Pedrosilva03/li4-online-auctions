using System.Data.SqlClient;
using app.Leiloeira.Pessoas;

namespace app.Data
{
    public class PessoaDAO
    {
        private static PessoaDAO? singleton = null;

        private PessoaDAO() { }

        public static PessoaDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new PessoaDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string cmd1 = "SELECT * FROM dbo.Pessoa WHERE id = @Key";
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
                throw new DAOException("Erro no containsKey do PessoaDAO");
            }
            return result;
        }

        public bool containsValue(Pessoa value)
        {
            return containsKey(value.getID());
        }
        
        public Pessoa get(int key)
        {
            Pessoa? p = null;
            string cmd1 = $"SELECT * FROM dbo.Pessoa where id = @Key";
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
                                decimal saldo = reader.GetDecimal(reader.GetOrdinal("saldo"));
                                string email = reader.GetString(reader.GetOrdinal("email"));
                                string password = reader.GetString(reader.GetOrdinal("password"));
                                int telemovel = reader.GetInt32(reader.GetOrdinal("telemovel"));
                                string nickname = reader.GetString(reader.GetOrdinal("nickname"));
                                
                                TipoDePessoa tipo = (TipoDePessoa)Enum.Parse(typeof(TipoDePessoa), reader.GetString(reader.GetOrdinal("tipo")));
                                Estado estado = (Estado)Enum.Parse(typeof(Estado), reader.GetString(reader.GetOrdinal("estado")));
                                p = new Pessoa(id, saldo, email, password, telemovel, nickname, tipo, null, null, estado);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do PessoaDAO");
            }
            return p;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public ICollection<int> keys()
        {
            ICollection<int> keys = new List<int>();
            string cmd = "SELECT id FROM dbo.Pessoa";
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
                throw new DAOException("Erro no keys do PessoaDAO");
            }
            return keys;
        }

        public void put(int key, Pessoa value)
        {
            string cmd;
            if (containsKey(key))
            {
                cmd = "UPDATE dbo.Pessoa SET id = @key, saldo = @saldo, email = @email, password = @password, telemovel = @telemovel, nickname = @nickname, tipo = @tipo, estado = @estado WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Pessoa (id, saldo, email, password, telemovel, nickname, tipo, estado) VALUES (@Key, @saldo, @email, @password, @telemovel, @nickname, @tipo, @estado)";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", key);
                        command.Parameters.AddWithValue("@saldo", value.getSaldo());
                        command.Parameters.AddWithValue("@email", value.getEmail());
                        command.Parameters.AddWithValue("@password", value.getPassword());
                        command.Parameters.AddWithValue("@telemovel", value.getTelemovel());
                        command.Parameters.AddWithValue("@nickname", value.getNickname());
                        command.Parameters.AddWithValue("@tipo", value.getTipo().ToString());
                        command.Parameters.AddWithValue("@estado", value.getEstado().ToString());
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do PessoaDAO");
            }
        }

        public Pessoa remove(int key)
        {
            Pessoa? p = get(key);
            if (p != null)
            {
                string cmd = "DELETE FROM dbo.Pessoa WHERE id = @Key";

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
                    throw new DAOException("Erro no remove do PessoaDAO");
                }
            }
            return p;
        }

        public int size()
        {
            int count = 0;
            string cmd = "SELECT COUNT(*) FROM dbo.Pessoa";
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
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
                Console.WriteLine("Stack trace: " + e.StackTrace);
                throw new DAOException("Erro no size do PessoaDAO");
            }
            return count;
        }

        public ICollection<Pessoa> values()
        {
            ICollection<Pessoa> pessoas = new List<Pessoa>(); 
            string cmd = "SELECT * FROM dbo.Pessoa"; 
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
                                decimal saldo = reader.GetDecimal(reader.GetOrdinal("saldo"));
                                string email = reader.GetString(reader.GetOrdinal("email"));
                                string password = reader.GetString(reader.GetOrdinal("password"));
                                int telemovel = reader.GetInt32(reader.GetOrdinal("telemovel"));
                                string nickname = reader.GetString(reader.GetOrdinal("nickname"));
                                
                                TipoDePessoa tipo = (TipoDePessoa)Enum.Parse(typeof(TipoDePessoa), reader.GetString(reader.GetOrdinal("tipo")));
                                Estado estado = (Estado)Enum.Parse(typeof(Estado), reader.GetString(reader.GetOrdinal("estado")));
                                Pessoa p = new Pessoa(id, saldo, email, password, telemovel, nickname, tipo, null, null, estado);
                                pessoas.Add(p);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
                Console.WriteLine("Stack trace: " + e.StackTrace);
                throw new DAOException("Erro no values do PessoaDAO");
            }
            return pessoas;
        }


        public void update_saldo(int idPessoa, decimal saldo)
        {
            string cmd = "UPDATE dbo.Pessoa SET saldo = @saldo WHERE id = @Key";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", idPessoa);
                        command.Parameters.AddWithValue("@saldo", saldo);
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no update_saldo do PessoaDAO");
            }
        }
    }
}