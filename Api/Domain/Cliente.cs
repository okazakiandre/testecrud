using System;

namespace TesteCrud.Api.Domain
{
    public class Cliente
    {
        public long NumeroCpfCnpj { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Tipo { get; set; }
    }
}
