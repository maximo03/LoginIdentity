using Dapper;
using Login.Models;
using Microsoft.Data.SqlClient;

namespace Login.Servicios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario> BuscarUsuarioPorEmail(string EmailNormalizado);
        Task<int> CrearUsuario(Usuario usuario);
    }
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        private readonly string connectionString;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CrearUsuario(Usuario usuario)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(
                @"INSERT INTO Usuarios(Name,Email,EmailNormalizado,PasswordHash)
                VALUES (@Name,@Email,@EmailNormalizado,@PasswordHash);
                SELECT SCOPE_IDENTITY();", usuario);
            return id;
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string EmailNormalizado)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return await connection.QuerySingleOrDefaultAsync<Usuario>(
               @"SELECT * FROM Usuarios WHERE EmailNormalizado=@EmailNormalizado",
               new { EmailNormalizado });

        }


    }
}
