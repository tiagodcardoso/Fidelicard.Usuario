using System.Data;

namespace Fidelicard.Usuario.Infra.Config
{
    public interface IDatabaseContext
    {
        IDbConnection GetConnection();
    }
}