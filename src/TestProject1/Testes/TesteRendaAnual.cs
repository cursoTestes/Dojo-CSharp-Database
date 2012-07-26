using SistemaVendas.Negocio;
using MbUnit.Framework;
using NHibernate;
using System.Collections;
using SistemaVendas.Model;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRendaAnual : TesteBase
    {
        private const int IdParaConsultar = 1;
        private ISession _session;

        [SetUp]
        public void Initialize()
        {
            //colocar codigo comum a varios testes dentro deste metodo. Ele é rodado antes dos testes.
            _session = Contexto.SessionFactory.OpenSession();
        }


        [Test]
        public void testeRendaAnual()
        {

           double rendaAnual = GeraRendaAnual.calcularRendaPorAnoVendedor(171, 2011, _session);

           Assert.AreEqual(2121.12, rendaAnual);
        }
    }
}
