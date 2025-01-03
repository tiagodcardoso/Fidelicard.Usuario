using Fidelicard.Usuario.Core.Interface;
using Fidelicard.Usuario.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Fidelicard.Usuario.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/fidelicard/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioService service,
           ILogger<UsuarioController> logger,
           IConfiguration configuration)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("obterUsuario")]
        [SwaggerResponse(StatusCodes.Status200OK, "Consultar usuário obtido com sucesso", typeof(UsuarioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não autorizado")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Acesso negado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ObterUsuario([FromRoute] int idUsuario)
        {
            if (idUsuario == 0)
            {
                return BadRequest(new { Mensagem = "Código do usuário invalido" });
            }

            try
            {
                var response = await _service.ConsultarUsuarioAsync(idUsuario).ConfigureAwait(false);

                if (response == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Mensagem = "Erro ao obter o usuário. Tente novamente mais tarde." });
                }

                return Ok(response);
            }            
            catch (UnauthorizedAccessException authEx)
            {
                _logger.LogWarning("Falha de autenticação: {Message}", authEx.Message);
                return Unauthorized(new { Mensagem = "Acesso não autorizado." });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro inesperado ao obter Usuário: {Message} - STACKTRACE: {StackTrace}", ex.Message, ex.StackTrace);

                var errorDetails = new
                {
                    Mensagem = "Erro inesperado ao processar sua solicitação. Tente novamente mais tarde.",
                    Controle = new
                    {
                        Codigo = "USUARIO.500",
                        Descricao = "Erro no processamento de Obter Usuário"
                    }
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorDetails);
            }
        }


        [HttpPost("cadastro")]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário cadastrado com sucesso", typeof(UsuarioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não autorizado")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Acesso negado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new { Mensagem = "O corpo da requisição não pode ser nulo." });
            }

            try
            {
                var response = await _service.CadastrarUsuarioAsync(usuario).ConfigureAwait(false);

                if (response == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Mensagem = "Erro ao processar o cadastro do usuário. Tente novamente mais tarde." });
                }

                return Ok(response);
            }
            catch (ArgumentException argEx)
            {
                _logger.LogWarning("Validação falhou ao processar Cadastrar Usuário: {Message}", argEx.Message);
                return BadRequest(new { Mensagem = argEx.Message });
            }
            catch (UnauthorizedAccessException authEx)
            {
                _logger.LogWarning("Falha de autenticação: {Message}", authEx.Message);
                return Unauthorized(new { Mensagem = "Acesso não autorizado." });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro inesperado ao processar Cadastrar Usuário: {Message} - STACKTRACE: {StackTrace}", ex.Message, ex.StackTrace);

                var errorDetails = new
                {
                    Mensagem = "Erro inesperado ao processar sua solicitação. Tente novamente mais tarde.",
                    Controle = new
                    {
                        Codigo = "USUARIO.500",
                        Descricao = "Erro no processamento de Cadastrar Usuário"
                    }
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorDetails);
            }
        }

        [HttpPut("atualizarUsuario")]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário atualizado com sucesso", typeof(UsuarioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não autorizado")]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Acesso negado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new { Mensagem = "O corpo da requisição não pode ser nulo." });
            }

            try
            {
                var response = await _service.AtualizarUsuarioAsync(usuario).ConfigureAwait(false);

                if (response == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Mensagem = "Erro ao processar a atualização no cadastro do usuário. Tente novamente mais tarde."});
                }

                return Ok(response);
            }
            catch (ArgumentException argEx)
            {
                _logger.LogWarning("Validação falhou ao processar Cadastrar Usuário: {Message}", argEx.Message);
                return BadRequest(new { Mensagem = argEx.Message });
            }
            catch (UnauthorizedAccessException authEx)
            {
                _logger.LogWarning("Falha de autenticação: {Message}", authEx.Message);
                return Unauthorized(new { Mensagem = "Acesso não autorizado." });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro inesperado ao processar a atualização do cadastro do Usuário: {Message} - STACKTRACE: {StackTrace}", ex.Message, ex.StackTrace);

                var errorDetails = new
                {
                    Mensagem = "Erro inesperado ao processar sua solicitação. Tente novamente mais tarde.",
                    Controle = new
                    {
                        Codigo = "USUARIO.500",
                        Descricao = "Erro no processamento de Atualizar Usuário"
                    }
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorDetails);
            }
        }
    }
}
