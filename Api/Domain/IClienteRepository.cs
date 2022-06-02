using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteCrud.Api.Domain
{
    public interface IClienteRepository
    {
        Task<bool> Incluir(Cliente cli);
        Task<long> Atualizar(Cliente cli);
        Task<List<Cliente>> Consultar(string nomeParcial = null, DateTime? dataInicial = null, DateTime? dataFinal = null);
        Task<bool> Excluir(long cpfCnpj);
    }
}
