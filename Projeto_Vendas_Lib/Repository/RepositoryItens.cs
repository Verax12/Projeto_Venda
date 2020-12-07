using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Repository
{
    public class RepositoryItens : RepositoryBase<Item>, IRepositoryItem
    {
        private readonly ProjetoContext _context;
        public RepositoryItens(ProjetoContext context) : base(context)
        {
            _context = context;
        }
    }
}

