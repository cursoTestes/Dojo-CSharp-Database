using System;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using NHibernate;
using SistemaVendas.Negocio;
using SistemaVendas.Model;
using SistemaVendas;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteVenda : TesteBase
    {
        private ISession _session;
        private Venda _vendasDeUmVendedor;

        [SetUp]
        public void Initialize()
        {
            _session = Contexto.SessionFactory.OpenSession();
        }

        [Test]
        public void TotalVendasVendedor1Ano2011Retorna30()
        {
            var ano = 2011;
            var idVendedor = 1;
            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(30, gr.TotalVendasAnualPorVendedor(ano, idVendedor, _session));
        }

        [Test]
        public void TotalVendasVendedor1Ano2010Retorna100()
        {
            var ano = 2010;
            var idVendedor = 1;
            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(100, gr.TotalVendasAnualPorVendedor(ano, idVendedor,_session));
        }

        [Test]
        public void TotalVendasVendedor171Ano2009Retorna79_12()
        {
            var ano = 2009;
            var idVendedor = 171;
            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(79.12, gr.TotalVendasAnualPorVendedor(ano, idVendedor, _session));
        }

        [Test]
        public void TotalVendasParaOsVendedores200e300ParaOAno2011Retorna500ParaCadaVendedor()
        {
            var ano = 2011;
            var idVendedorA = 200;
            var idVendedorB = 300;

            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(500, gr.TotalVendasAnualPorVendedor(ano, idVendedorA, _session));
            Assert.AreEqual(500, gr.TotalVendasAnualPorVendedor(ano, idVendedorB, _session));
        }

        [Test]
        public void TotalVendasParaOsVendedores400e500ParaOAno2011Retorna100ParaVendedor400ERetorna40ParaOVendedor500()
        {
            var ano = 2011;
            var idVendedorA = 400;
            var idVendedorB = 500;

            GeradorRelatorio gr = new GeradorRelatorio();
            Assert.AreEqual(100, gr.TotalVendasAnualPorVendedor(ano, idVendedorA, _session));
            Assert.AreEqual(40, gr.TotalVendasAnualPorVendedor(ano, idVendedorB, _session));
        }



    }


}
