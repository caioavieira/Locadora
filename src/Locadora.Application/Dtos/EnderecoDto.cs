namespace Locadora.Application.Dtos
{
    public class EnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
    }
}