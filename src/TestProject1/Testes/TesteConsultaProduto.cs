using SistemaVendas.Negocio;
using MbUnit.Framework;
using NHibernate;
using SistemaVendas.Model;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteConsultaProduto : TesteBase
    {
        private const int IdParaConsultar = 1;
        private ISession _session;
        private Produto _produtoEncontrado;

        [SetUp]
        public void Initialize()
        {
            //colocar codigo comum a varios testes dentro deste metodo. Ele é rodado antes dos testes.
        }


        [Test]
        public void ExisteNoBD()
        {
            _session = Contexto.SessionFactory.OpenSession();
            
            _produtoEncontrado = _session.Get<Produto>(IdParaConsultar);

            Assert.IsNotNull(_produtoEncontrado);
        }
        [Test]
        public void TemNomeCorreto()
        {

            _session = Contexto.SessionFactory.OpenSession();

            _produtoEncontrado = _session.Get<Produto>(IdParaConsultar);

            Assert.AreEqual("Bombril", _produtoEncontrado.Nome);
        }
    }
}
