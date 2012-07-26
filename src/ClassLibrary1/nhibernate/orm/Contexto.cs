using NHibernate;

namespace SistemaVendas.Negocio
{
    public class Contexto
    {
        public static ISessionFactory SessionFactory { get; set; }
    }
}