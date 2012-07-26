using MbUnit.Framework;

namespace TestProject1
{
    
    
    public abstract class TesteBase 
    {
        [SetUp]
        public virtual void TestInitialize() 
        {
            OperacoesDeTestes.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeTeste);
        }
    }
    

}