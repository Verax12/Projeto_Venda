using System.Collections.Generic;

namespace Projeto_Vendas_Lib.Domain
{
    public class Item : BaseModel
    {
        public string Descricao { get; set; }
        public decimal QuantidadeEmEstoque { get; set; }
        public double Preco { get; set; }
    }
}