using Npgsql;
using System.Numerics;
using techTutor.Domain.Entity;
using techTutor.Domain.Interfaces;
using techTutor.Infra.ConnectionDb;

namespace techTutor.Infra.Repository
{
    public class Login : ILogin
    {
        private DbConnection _connectionString;
        public Login(IConfiguration configuration)
        {
            _connectionString = new DbConnection(configuration);
        }
        public bool AddLogin(Usuario usuario)
        {
            using var conn = new NpgsqlConnection(_connectionString.GetString());
            conn.Open();

            string query = "INSERT INTO usuario (userName, pasword, score) VALUES (@nome, @senha, 0)";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", usuario.UserName);
            cmd.Parameters.AddWithValue("senha", usuario.Pasword);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }

        public bool GetLogin(Usuario usuario)
        {
            using var conn = new NpgsqlConnection(_connectionString.GetString());
            conn.Open();

            string query = "SELECT COUNT(*) FROM usuario WHERE userName = @nome AND pasword = @senha";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", usuario.UserName);
            cmd.Parameters.AddWithValue("senha", usuario.Pasword);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;
        }
    }
}
