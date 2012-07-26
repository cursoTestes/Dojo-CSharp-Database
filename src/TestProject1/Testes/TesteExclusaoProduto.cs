using SistemaVendas.Negocio;
using MbUnit.Framework;
using NHibernate;
using SistemaVendas.Model;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteExclusaoProduto : TesteBase
    {
        private const int IdParaExcluir = 1;
        private ISession _session;

        [SetUp]
        public void Initialize()
        {
            preparaCenario();

            chamaRegraNegocio();
        }

        private void preparaCenario()
        {
            _session = Contexto.SessionFactory.OpenSession();
        }

        private void chamaRegraNegocio()
        {
            var produtoParaExcluir = _session.Get<Produto>(IdParaExcluir);
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(produtoParaExcluir);
                tran.Commit();
            }
        }

        [Test]
        public void NaoEstaNoBD()
        {
            _session.Clear();
            var produtoExcluido = _session.Get<Produto>(IdParaExcluir);
            Assert.IsNull(produtoExcluido);
        }
    }
}