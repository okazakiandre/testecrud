using MongoDB.Driver;
using TesteCrud.Api.Domain;
using System;
using System.Collections.Generic;

namespace TesteCrud.Api.Infrastructure.RepositoryDefinitions
{
    public class ClienteUpdateDefinition
    {
        public static UpdateDefinition<Cliente> Criar(Cliente cli)
        {
            List<UpdateDefinition<Cliente>> campos = new List<UpdateDefinition<Cliente>>();
            if (! string.IsNullOrEmpty(cli.Nome))
            {
                campos.Add(Builders<Cliente>.Update.Set(c => c.Nome, cli.Nome));
            }
            if (cli.DataNascimento > DateTime.MinValue)
            {
                campos.Add(Builders<Cliente>.Update.Set(c => c.DataNascimento, cli.DataNascimento));
            }
            if (cli.Telefone > 0)
            {
                campos.Add(Builders<Cliente>.Update.Set(c => c.Telefone, cli.Telefone));
            }
            return Builders<Cliente>.Update.Combine(campos);
        }
    }
}
