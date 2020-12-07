using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Domain
{
    public class Venda : BaseModel
    {
        public Cliente cliente { get; set; }
        public Vendedor vendedor { get; set; }

        public IEnumerable<Item> itens { get; set; }
    }
}
