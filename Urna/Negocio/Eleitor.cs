using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Urna.Negocio
{
    public class Eleitor
    {
        private MySqlConnection connection;
        public Eleitor()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.Eleitor Read(string id)
        {
            return this.Read(id, "", "", "", "").FirstOrDefault();
        }

        public List<Classes.Eleitor> Read(string id, string nome, string titulo, string zona, string secao)
        {
            var eleitor = new List<Classes.Eleitor>();

            try
            {
                connection.Open();
                var comando = new MySqlCommand($"SELECT nome, titulo, Zona, Secao, id FROM eleitor WHERE (1=1) ", connection);
                if(nome.Equals("") == false)
                {
                    comando.CommandText += $" AND nome like @nome";
                    comando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
                }
                if(titulo.Equals("") == false)
                {
                    comando.CommandText += $" AND titulo = @titulo";
                    comando.Parameters.Add(new MySqlParameter("titulo", titulo));
                }
                if(zona.Equals("") == false)
                {
                    comando.CommandText += $" AND Zona = @zona";
                    comando.Parameters.Add(new MySqlParameter("Zona", zona));
                }
                if(secao.Equals("") == false)
                {
                    comando.CommandText += $" AND Secao = @secao";
                    comando.Parameters.Add(new MySqlParameter("Secao", secao));
                }
                if(id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    eleitor.Add(new Classes.Eleitor
                    {
                        Nome = reader.GetString("nome"),
                        Id = reader.GetInt32("id"),
                        Titulo = reader.GetString("titulo"),
                        Zona = reader.GetString("zona"),
                        Secao = reader.GetString("secao")
                    });
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return eleitor;
        }

        public bool Create(Classes.Eleitor eleitor)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO eleitor (nome, titulo, Zona, Secao) VALUES (@nome, @titulo, @Zona, @Secao)", connection);
                comando.Parameters.Add(new MySqlParameter("nome", eleitor.Nome));
                comando.Parameters.Add(new MySqlParameter("titulo", eleitor.Titulo));
                comando.Parameters.Add(new MySqlParameter("Zona", eleitor.Zona));
                comando.Parameters.Add(new MySqlParameter("Secao", eleitor.Secao));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.Eleitor eleitor)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"UPDATE eleitor SET nome = @nome, titulo = @titulo, Zona = @Zona, Secao = @Secao WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("nome", eleitor.Nome));
                comando.Parameters.Add(new MySqlParameter("titulo", eleitor.Titulo));
                comando.Parameters.Add(new MySqlParameter("Zona", eleitor.Zona));
                comando.Parameters.Add(new MySqlParameter("Secao", eleitor.Secao));
                comando.Parameters.Add(new MySqlParameter("id", eleitor.Id));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand("DELETE FROM eleitor WHERE id = " + id, connection);
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}