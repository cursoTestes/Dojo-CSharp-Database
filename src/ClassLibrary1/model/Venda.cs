using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Model
{
    public class Venda
    {
        public virtual int IdVenda { get; set; }
        public virtual DateTime dataVenda { get; set; }
        public virtual double valor { get; set; }
    }

}
