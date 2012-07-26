using FluentNHibernate.Mapping;
using SistemaVendas.Model;

namespace SistemaVendas.Negocio
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("ProdutoId", "NextHi", "2");
            Map(x => x.Nome);
        }
    }
}