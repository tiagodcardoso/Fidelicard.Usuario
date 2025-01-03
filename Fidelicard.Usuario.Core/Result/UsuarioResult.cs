using Fidelicard.Usuario.Core.Models;

namespace Fidelicard.Usuario.Core.Result
{
    public class UsuarioResult
    {
        public UsuarioStatus Status { get; protected set; }

        public Usuarios Usuarios { get; protected set; }

        public Exception ErroProcessamento { get; protected set; }
        
        public string Mensagem { get; protected set; }

        protected UsuarioResult(UsuarioStatus status, Usuarios usuarios, Exception erroProcessamento, string mensagem)
        {
            Status = status;
            Usuarios = usuarios;
            ErroProcessamento = erroProcessamento;
            Mensagem = mensagem;
        }

        public static UsuarioResult SucessoObterUsuario(Usuarios usuarios) =>
            new UsuarioResult(UsuarioStatus.SucessoObterUsuario, usuarios, null, string.Empty);

        public static UsuarioResult DadosInvalidos(Exception erroProcessamento, string mensagem) =>
           new UsuarioResult(UsuarioStatus.DadosInvalidos, null, erroProcessamento, mensagem);

        public static UsuarioResult ErroObterUsuario(Exception erroProcessamento, string mensagem) =>
            new UsuarioResult(UsuarioStatus.ErroObterUsuario, null, erroProcessamento, mensagem);
    }
}
