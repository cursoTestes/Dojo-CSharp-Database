using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace SistemaVendas.Negocio
{


    public static class Configurador
    {
        public static void Configurar()
        {
            Configurar(false, false);
        }

        public static void Configurar(bool showSql, bool criarBD)
        {
            if (Contexto.SessionFactory != null)
                return;

            Contexto.SessionFactory = CriarObjetoDeConfiguracaoDoNH()
                .ConfigurarMapeamentos()
                .ConfigurarBancoDeDados(showSql)
                .CriarBD(criarBD)
                .BuildSessionFactory();
        }

        private static FluentConfiguration ConfigurarBancoDeDados(this FluentConfiguration configFluente, bool showSql)
        {
            configFluente.ConfigurarStringConexao(MsSqlConfiguration.MsSql2005, showSql);
            return configFluente;
        }

        private static FluentConfiguration ConfigurarMapeamentos(this Configuration config)
        {
            return Fluently.Configure(config)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProdutoMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<VendaMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<VendaVendedorMap>());
        }

        private static FluentConfiguration CriarBD(this FluentConfiguration configFluente, bool criarBD)
        {
            if (criarBD)
                configFluente.ExposeConfiguration(
                    config =>
                    {
                        new SchemaExport(config).Drop(true, true);
                        new SchemaExport(config).Create(true, true);
                    }
                    );
            return configFluente;
        }

        private static Configuration CriarObjetoDeConfiguracaoDoNH()
        {
            var config = new Configuration();
            config.Properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
            return config;
        }

        private static void ConfigurarStringConexao<TThisConfiguration, TConnectionString>(
            this FluentConfiguration configFluente,
            PersistenceConfiguration<TThisConfiguration, TConnectionString> persistenceConfiguration,
            bool showSql)
            where TThisConfiguration : PersistenceConfiguration<TThisConfiguration, TConnectionString>
            where TConnectionString : ConnectionStringBuilder, new()
        {
            const string connectionStringKey = "ExemploConexao";
            if (showSql) persistenceConfiguration.ShowSql();
            persistenceConfiguration.ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey));
            configFluente.Database(persistenceConfiguration);
        }
    }
}
