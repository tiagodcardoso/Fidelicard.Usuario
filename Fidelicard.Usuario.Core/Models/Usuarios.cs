namespace Fidelicard.Usuario.Core.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pessoa { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public int Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
