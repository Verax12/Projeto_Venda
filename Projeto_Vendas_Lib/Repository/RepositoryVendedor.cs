using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Repository
{
    public class RepositoryVendedor : RepositoryBase<Vendedor>, IRepositoryVendedor
    {
        private readonly ProjetoContext _context;
        public RepositoryVendedor(ProjetoContext context) : base(context)
        {
            _context = context;
        }

    }
}
