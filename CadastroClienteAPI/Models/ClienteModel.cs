namespace CadastroClienteAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string Sobrenome { get; set; }
        public string  Rua { get; set; }
        public  string Bairro { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }

    }
}
