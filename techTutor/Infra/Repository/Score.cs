using Npgsql;
using techTutor.Domain.Entity;
using techTutor.Domain.Interfaces;
using techTutor.Infra.ConnectionDb;

namespace techTutor.Infra.Repository
{
    public class Score : IScore
    {
        private DbConnection _connectionString;
        public Score(IConfiguration configuration)
        {
            _connectionString = new DbConnection(configuration);
        }
        public bool AddScore(Usuario usuario)
        {
            using var conn = new NpgsqlConnection(_connectionString.GetString());
            conn.Open();

            string query = "UPDATE usuario SET score = score + @pontos WHERE username = @nome";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", usuario.UserName);
            cmd.Parameters.AddWithValue("pontos", usuario.Score);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }

        public Usuario GetScore(Usuario usuario)
        {
            using var conn = new NpgsqlConnection(_connectionString.GetString());
            conn.Open();

            string query = "SELECT score FROM usuario WHERE userName = @nome ";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", usuario.UserName);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var usuarioRetornado = new Usuario
                {
                  
                    Score = reader.GetInt32(0)       
                };

                return usuarioRetornado;
            }
            else
            {
                return null; 
            }
        }
    }
}
