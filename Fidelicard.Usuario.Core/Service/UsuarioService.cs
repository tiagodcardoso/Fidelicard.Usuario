using Fidelicard.Usuario.Core.Interface;
using Fidelicard.Usuario.Core.Models;
using Fidelicard.Usuario.Core.Result;
using Microsoft.Extensions.Logging;

namespace Fidelicard.Usuario.Core.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(ILogger<UsuarioService> logger
        , IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioResult> ConsultarUsuarioAsync(int idUsuario)
        {
            _logger.LogInformation("Iniciando consulta do usuário com Id: {IdUsuario}", idUsuario);

            try
            {
                var usuario = await _usuarioRepository.ObterUsuarioAsync(idUsuario).ConfigureAwait(false);

                if (usuario == null)
                {
                    var mensagem = $"Usuário inexistente pelo código informado: {idUsuario}";
                    _logger.LogWarning(mensagem);
                    return UsuarioResult.DadosInvalidos(new Exception(mensagem), mensagem);
                }

                _logger.LogInformation("Consulta do usuário com Id: {IdUsuario} concluída com sucesso.", idUsuario);
                return UsuarioResult.SucessoObterUsuario(usuario.Usuarios);
            }
            catch (Exception ex)
            {
                var mensagemErro = $"Erro ao consultar o usuário com Id: {idUsuario}.";
                _logger.LogError(ex, mensagemErro);
                return UsuarioResult.ErroObterUsuario(ex, mensagemErro);
            }
        }

        public async Task<int> CadastrarUsuarioAsync(Usuarios usuario)
        {
            _logger.LogInformation("Iniciando cadastro do usuário: {UsuarioNome}", usuario?.Nome);

            try
            {
                var result = await _usuarioRepository.CadastrarUsuarioAsync(usuario).ConfigureAwait(false);

                _logger.LogInformation("Usuário cadastrado com sucesso. Id gerado: {UsuarioId}", result);
                return result;
            }
            catch (Exception ex)
            {
                var mensagemErro = "Erro ao cadastrar o usuário.";
                _logger.LogError(ex, mensagemErro);
                throw new ApplicationException(mensagemErro, ex);
            }
        }

        public async Task<int> AtualizarUsuarioAsync(Usuarios usuario)
        {
            _logger.LogInformation("Iniciando cadastro do usuário: {UsuarioNome}", usuario?.Nome);

            try
            {
                var result = await _usuarioRepository.AtualizarUsuarioAsync(usuario).ConfigureAwait(false);

                _logger.LogInformation("Usuário atualizado com sucesso. Id gerado: {UsuarioId}", result);
                return result;
            }
            catch (Exception ex)
            {
                var mensagemErro = "Erro ao atualizar o usuário.";
                _logger.LogError(ex, mensagemErro);
                throw new ApplicationException(mensagemErro, ex);
            }
        }        
    }
}
