using Fidelicard.Usuario.Core.Models;
using Fidelicard.Usuario.Core.Result;
using System.Data;

namespace Fidelicard.Usuario.Core.Interface
{
    public interface IUsuarioRepository
    {
        Task<UsuarioResult> ObterUsuarioAsync(int idUsuario);
        Task<int> CadastrarUsuarioAsync(Usuarios usuario);
        Task<int> AtualizarUsuarioAsync(Usuarios usuario);

        IDbConnection GetConnection();
    }
}
