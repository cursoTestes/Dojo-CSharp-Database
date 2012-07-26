using FluentNHibernate.Mapping;
using SistemaVendas.Model;

namespace SistemaVendas.Negocio
{
    public class VendaVendedorMap : ClassMap<VendaVendedor>
    {
        public VendaVendedorMap()
        {
            Id(x => x.IdVendaVendedor).GeneratedBy.Identity();
            Map(x => x.IdVenda);
            Map(x => x.IdVendedor);
            Map(x => x.valor);
        }
    }

}