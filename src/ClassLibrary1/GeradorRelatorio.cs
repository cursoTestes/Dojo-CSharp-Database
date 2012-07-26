using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SistemaVendas
{
    public class GeradorRelatorio
    {
        public double TotalVendasAnualPorVendedor(int ano, int idVendedor, ISession _session)
        {

            string query = "select sum(vv.valor)  from venda v inner join vendavendedor vv on vv.IdVenda = v.Idvenda where vv.IdVendedor = :idVendedor and year(v.dataVenda)= :ano";

            double valorVendas = _session.CreateSQLQuery(query)
                .SetParameter("idVendedor", idVendedor)
                    .SetParameter("ano", ano).UniqueResult<double>();


            return valorVendas;
        }
    }
}
