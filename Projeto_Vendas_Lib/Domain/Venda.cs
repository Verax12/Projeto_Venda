using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Domain
{
    public class Venda : BaseModel
    {
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public Vendedor Vendedor { get; set; }
        public Guid VendedorId { get; set; }
        
        public ICollection<Item> Itens { get; set; }
    }
}
