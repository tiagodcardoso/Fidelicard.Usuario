namespace Fidelicard.Usuario.Core.Models
{
    public class UsuarioResponse
    {
        public string Id { get; set; }
        public int statusCode { get; set; }
        public string DataCadastro { get; set; }       
        public bool HasError { get; set; }
        public string Erro { get; set; }
    }
}
