﻿using Fidelicard.Usuario.Infra.Config;
using System.Data;

namespace Fidelicard.Usuario.Infra.Repository
{
    public class BaseRepository
    {
        private readonly IDatabaseContext _conexaoBanco;

        public BaseRepository(IDatabaseContext conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }

        public IDbConnection GetConnection()
        {
            return _conexaoBanco.GetConnection();
        }
    }
}
