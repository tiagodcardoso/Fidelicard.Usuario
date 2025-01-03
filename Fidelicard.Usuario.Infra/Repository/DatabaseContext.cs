using Fidelicard.Usuario.Infra.Config;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Fidelicard.Usuario.Infra.Repository
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly string _connectionString;

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public DatabaseContext(IConfiguration config)
        {
            _connectionString = config.GetSection("ConnectionStrings:DBUsuario").Value;
        }
    }
}
