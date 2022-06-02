using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteCrud.Api.Infrastructure.RepositoryDefinitions;

namespace TesteCrud.UnitTest.Infrastructure.RepositoryDefinitions
{
    [TestClass]
    [TestCategory("UnitTest > Infrastructure > RepositoryDefinitions")]
    public class ClienteFilterDefinitionTest
    {
        [TestMethod]
        public void DeveriaCriarFiltroDeClientesSomentePeloTipo2()
        {
            var filtro = ClienteFilterDefinition.Criar();
            var campos = CamposDoDefinition.ObterDoFilter(filtro);
            Assert.AreEqual(1, campos.Length);
            Assert.AreEqual("Tipo=2", campos[0]);
        }

        [TestMethod]
        public void DeveriaCriarFiltroDeClientesPorNome1111()
        {
            var filtro = ClienteFilterDefinition.Criar("1111");
            var campos = CamposDoDefinition.ObterDoFilter(filtro);
            Assert.AreEqual(2, campos.Length);
            Assert.AreEqual("Tipo=2", campos[0]);
            Assert.AreEqual("Nome=/1111/", campos[1]);
        }

        [TestMethod]
        public void DeveriaCriarFiltroDeClientesQueTemDataInicial()
        {
            var filtro = ClienteFilterDefinition.Criar(dataInicial: new DateTime(2020, 1, 10));
            var campos = CamposDoDefinition.ObterDoFilter(filtro);
            Assert.AreEqual(2, campos.Length);
            Assert.AreEqual("Tipo=2", campos[0]);
            Assert.AreEqual("DataCadastro={ \"$gte\" : ISODate(\"2020-01-10T03:00:00Z\") }", campos[1]);
        }

        [TestMethod]
        public void DeveriaCriarFiltroDeClientesQueTemDataFinal()
        {
            var filtro = ClienteFilterDefinition.Criar(dataFinal: new DateTime(2020, 1, 10));
            var campos = CamposDoDefinition.ObterDoFilter(filtro);
            Assert.AreEqual(2, campos.Length);
            Assert.AreEqual("Tipo=2", campos[0]);
            Assert.AreEqual("DataCadastro={ \"$lte\" : ISODate(\"2020-01-10T03:00:00Z\") }", campos[1]);
        }

        [TestMethod]
        public void DeveriaCriarFiltroDeClientesComNomeEPeriodo()
        {
            var filtro = ClienteFilterDefinition.Criar("33", new DateTime(2020, 5, 1), new DateTime(2020, 5, 22));
            var campos = CamposDoDefinition.ObterDoFilter(filtro);
            Assert.AreEqual(3, campos.Length);
            Assert.AreEqual("Tipo=2", campos[0]);
            Assert.AreEqual("Nome=/33/", campos[1]);
            Assert.AreEqual("DataCadastro={ \"$gte\" : ISODate(\"2020-05-01T03:00:00Z\"), \"$lte\" : ISODate(\"2020-05-22T03:00:00Z\") }", campos[2]);
        }
    }
}
