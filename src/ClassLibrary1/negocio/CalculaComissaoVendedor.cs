using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace SistemaVendas.Negocio
{
    public static class CalculaComissaoVendedor
    {
        public static double calcularTotal(double totalVendas)
        {
            //a comissao é de 5% no total do valor de vendas
            double valorComissao = totalVendas * 0.05;

            return valorComissao;
        }

    }
}
