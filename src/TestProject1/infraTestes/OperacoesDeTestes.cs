using System.Data;
using System.Data.SqlClient;
using NDbUnit.Core.SqlClient;
using NDbUnit.Core;

namespace TestProject1
{
    public static class OperacoesDeTestes
    {
        public static void CarregarBancoDeDados(
            string esquema,
            string dados)
        {
            var baseDeDados = ObterBaseDeDados();
            baseDeDados.ReadXmlSchema(esquema);
            baseDeDados.ReadXml(dados);
            baseDeDados.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);
        }

        private static INDbUnitTest ObterBaseDeDados()
        {
            var baseDeDados = new SqlDbUnitTest(ConfiguracaoDeTestes.StringDeConexao);
            return baseDeDados;
        }

    }
}
