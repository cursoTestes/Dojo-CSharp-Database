using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Criterion;
using System.Collections.Generic;
using SistemaVendas.Model;

namespace SistemaVendas.Negocio
{
    public static class GeraValorDemonstrativoIRPF
    {

        public static double calcularTotal(int idVendedor, int ano, ISession _session )
        {
            double totalVendas=0.0;
            //a comissao é de 5% no total do valor de vendas
            IList<Venda>  lista = _session.CreateCriteria(typeof(Venda))
                                          .Add(Restrictions.Eq("IdVendedor", 1))
                                      .List<Venda>();

            foreach (Venda v in lista)
            {
                totalVendas = totalVendas + v.valor;
            }

            double valorComissao = CalculaComissaoVendedor.calcularTotal(totalVendas);

            return valorComissao;
        }

    }
}
