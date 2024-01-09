using System.Data.SqlClient;
using app.Leiloeira.Leiloes;

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
                                decimal precoReserva = reader.GetDecimal(reader.GetOrdinal("precoReserva"));
                                decimal precoMinimo = reader.GetDecimal(reader.GetOrdinal("precoMinimo"));
                                DateTime dataHoraInicial = reader.GetDateTime(reader.GetOrdinal("dataHoraInicial"));
                                DateTime dataHoraFinal = reader.GetDateTime(reader.GetOrdinal("dataHoraFinal"));
                                int duracao = reader.GetInt32(reader.GetOrdinal("duracao"));
                                int id_lanceAtual = reader.GetInt32(reader.GetOrdinal("id_lanceAtual"));
                                int id_lanceFinal = reader.GetInt32(reader.GetOrdinal("id_lanceFinal"));


                                l = new Leilao(id, id_Criador, precoReserva, precoMinimo, dataHoraInicial, dataHoraFinal, duracao, id_lanceAtual, id_lanceFinal, null, null, null);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no get do ArtigoDAO");
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
                cmd = "UPDATE dbo.Leilao SET id = @key, id_Criador = @id_Criador, precoReserva = @precoReserva, precoMinimo = @precoMinimo, dataHoraInicial = @dataHoraInicial, dataHoraFinal = @dataHoraFinal, duracao = @duracao, id_lanceAtual = @id_lanceAtual, id_lanceFinal = @id_lanceFinal WHERE id = @Key";
            }
            else
            {
                cmd = "INSERT INTO dbo.Leilao (id, id_Criador, precoReserva, precoMinimo, dataHoraInicial, dataHoraFinal, duracao, id_lanceAtual, id_lanceFinal) VALUES (@Key, @id_Criador, @precoReserva, @precoMinimo, @dataHoraInicial, @dataHoraFinal, @duracao, @id_lanceAtual, @id_lanceFinal)";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        command.Parameters.AddWithValue("@Key", key);
                        command.Parameters.AddWithValue("@id_Criador", value.getId_Criador());
                        command.Parameters.AddWithValue("@precoReserva", value.getPrecoReserva());
                        command.Parameters.AddWithValue("@precoMinimo", value.getPrecoMinimo());
                        command.Parameters.AddWithValue("@dataHoraInicial", value.getDataHoraInicial());
                        command.Parameters.AddWithValue("@dataHoraFinal", value.getDataHoraFinal());
                        command.Parameters.AddWithValue("@duracao", value.getDuracao());
                        command.Parameters.AddWithValue("@id_lanceAtual", value.getIdLanceAtual());
                        command.Parameters.AddWithValue("@id_lanceFinal", value.getIdLanceFinal());

                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
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
                                Leilao l = new Leilao(
                                    reader.GetInt32(0), 
                                    reader.GetInt32(1), 
                                    reader.GetDecimal(2),
                                    reader.GetDecimal(3), 
                                    reader.GetDateTime(4),
                                    reader.GetDateTime(5),
                                    reader.GetInt32(6),
                                    reader.GetInt32(7),
                                    reader.GetInt32(8),
                                    null,
                                    null,
                                    null 
                                );
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
    }
}