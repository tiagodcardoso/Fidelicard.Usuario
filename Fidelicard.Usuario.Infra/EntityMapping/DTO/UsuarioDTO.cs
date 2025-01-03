using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fidelicard.Usuario.Infra.EntityMapping.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pessoa { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
