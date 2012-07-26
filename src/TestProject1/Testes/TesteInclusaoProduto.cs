using SistemaVendas.Negocio;
using MbUnit.Framework;
using NHibernate;
using SistemaVendas.Model;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteInclusaoProduto : TesteBase
    {
        private Produto _produtoParaIncluir;
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
            _produtoParaIncluir = new Produto
                                      {
                                          Nome = "um"
                                      };
        }

        private void chamaRegraNegocio()
        {
            using (var trans = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(_produtoParaIncluir);
                trans.Commit();
            }
        }

        [Test]
        public void NaoEhIgualAZero()
        {
            Assert.AreNotEqual(0, _produtoParaIncluir.Id);
        }

        [Test]
        public void EstaNoBD()
        {
            _session.Clear();
            var produtoIncluido = _session.Get<Produto>(_produtoParaIncluir.Id);
            Assert.AreEqual("um", produtoIncluido.Nome);
        }
    }
}