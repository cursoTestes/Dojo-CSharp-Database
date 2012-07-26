using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Model
{
    public class VendaVendedor
    {
        public virtual int IdVendaVendedor { get; set; }
        public virtual int IdVenda { get; set; }
        public virtual int IdVendedor { get; set; }
        public virtual double valor { get; set; }
    }
}
