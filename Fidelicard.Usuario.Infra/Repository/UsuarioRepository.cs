using AutoMapper;
using Dapper;
using Fidelicard.Usuario.Core.Interface;
using Fidelicard.Usuario.Core.Models;
using Fidelicard.Usuario.Core.Result;
using Fidelicard.Usuario.Infra.Config;
using Fidelicard.Usuario.Infra.EntityMapping.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;

namespace Fidelicard.Usuario.Infra.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public UsuarioRepository(IDatabaseContext context,
            ILogger<UsuarioRepository> logger,
            IMapper mapper,
            IConfiguration configuration) : base(context)
        {
            _logger = logger;
            _mapper = mapper;
            _connectionString = configuration.GetSection("ConnectionStrings:DBUsuario").Value;
        }
                
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        //public async Task<UsuarioResult> ObterUsuarioAsync(int idUsuario)
        //{
        //    try
        //    {
        //        using var connection = GetConnection();
        //        var query = @"SELECT 
        //                        usu.IdUsuario,
        //                        usu.Nome,
        //                        usu.Pessoa,
        //                        usu.Documento,
        //                        usu.Endereco,
        //                        usu.UF,
        //                        usu.Cidade,
        //                        usu.Ativo,
        //                        usu.DataCadastro,
        //                        usu.DataAtualizacao
        //                    FROM Usuario usu
        //                    WHERE usu.Id = @IdUsuario";

        //        var usuarioDto = await connection.QueryFirstOrDefaultAsync<UsuarioDTO>(
        //            sql: query,
        //            param: new { IdUsuario = idUsuario }
        //        ).ConfigureAwait(false);

        //        if (usuarioDto == null)
        //        {
        //            _logger.LogWarning("Usuário com Id {IdUsuario} não encontrado.", idUsuario);
        //            return null;
        //        }

        //        return _mapper.Map<UsuarioResult>(usuarioDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Erro ao obter o usuário com Id {IdUsuario}.", idUsuario);
        //        throw;
        //    }
        //}

        //public async Task<int> CadastrarUsuarioAsync(Usuarios usuario)
        //{
        //    var sql = @"INSERT INTO [dbo].[Usuario]
        //                (
        //                    Nome,
        //                    Pessoa,
        //                    Documento,
        //                    Endereco,
        //                    UF,
        //                    Cidade,
        //                    Ativo,
        //                    DataCadastro,
        //                    DataAtualizacao
        //                )                               
        //                VALUES 
        //                (
        //                    @Nome,
        //                    @Pessoa,
        //                    @Documento,
        //                    @Endereco,
        //                    @UF,
        //                    @Cidade,
        //                    true,
        //                    GETDATE(),
        //                    null
        //                );
        //                SELECT CAST(SCOPE_IDENTITY() as int);";

        //    using (var connection = GetConnection())
        //    {
        //        connection.Open();

        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            try
        //            {
        //                var result = await connection.ExecuteScalarAsync<int>(
        //                    sql,
        //                    new
        //                    {
        //                        usuario.Nome,
        //                        usuario.Pessoa,
        //                        usuario.Documento,
        //                        usuario.Endereco,
        //                        usuario.UF,
        //                        usuario.Cidade
        //                    },
        //                    transaction
        //                );

        //                transaction.Commit();
        //                return result;
        //            }
        //            catch
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}

        //public async Task<int> AtualizarUsuarioAsync(Usuarios usuario)
        //{
        //    const string sql = @"UPDATE [dbo].[Usuario]
        //                        SET Nome = @Nome,
        //                            Pessoa = @Pessoa,
        //                            Documento = @Documento,
        //                            Endereco = @Endereco,
        //                            UF = @UF,
        //                            Cidade = @Cidade,
        //                            Ativo = @Ativo,
        //                            DataAtualizacao = GETDATE()
        //                        WHERE Id = @IdUsuario";

        //    try
        //    {
        //        using var connection = GetConnection();
        //        connection.Open();

        //        var result = await connection.ExecuteAsync(sql, new
        //        {
        //            IdUsuario = usuario.Id,
        //            usuario.Nome,
        //            usuario.Pessoa,
        //            usuario.Documento,
        //            usuario.Endereco,
        //            usuario.UF,
        //            usuario.Cidade,
        //            usuario.Ativo
        //        }).ConfigureAwait(false);

        //        if (result == 0)
        //        {
        //            throw new InvalidOperationException($"Nenhum registro encontrado para o IdUsuario: {usuario.Id}");
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Erro ao atualizar o usuário com Id: {IdUsuario}", usuario.Id);
        //        throw;
        //    }
        //}

        /// <summary>
        /// Método mockado para obter um usuário.
        /// </summary>
        public Task<UsuarioResult> ObterUsuarioAsync(int idUsuario)
        {
            var usuarioMock = new Usuarios
            {
                Id = idUsuario,
                Nome = "Teste Usuario",
                Pessoa = "PF",
                Documento = "12345678900",
                Endereco = "Av Paulista 1346",
                UF = "SP",
                Cidade = "São Paulo",
                Ativo = 1,
                DataCadastro = DateTime.Now.AddYears(-1),
                DataAtualizacao = DateTime.Now
            };

            return Task.FromResult(UsuarioResult.SucessoObterUsuario(usuarioMock));
        }

        /// <summary>
        /// Método mockado para cadastrar um usuário.
        /// </summary>
        public Task<int> CadastrarUsuarioAsync(Usuarios usuario)
        {
            return Task.FromResult(1);
        }

        /// <summary>
        /// Método mockado para atualizar um usuário.
        /// </summary>
        public Task<int> AtualizarUsuarioAsync(Usuarios usuario)
        {
            return Task.FromResult(1);
        }
    }
}
