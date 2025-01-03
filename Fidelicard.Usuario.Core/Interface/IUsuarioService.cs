using Fidelicard.Usuario.Core.Models;
using Fidelicard.Usuario.Core.Result;

namespace Fidelicard.Usuario.Core.Interface
{
    public interface IUsuarioService
    {
        Task<int> CadastrarUsuarioAsync(Usuarios usuario);

        Task<UsuarioResult> ConsultarUsuarioAsync(int idUsuario);

        Task<int> AtualizarUsuarioAsync(Usuarios usuario);
    }
}
