using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Domain
{
    public abstract class Pessoa : BaseModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
