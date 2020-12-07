using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Infra.Context;
using Projeto_Vendas_Lib.Repository.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Repository
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly ProjetoContext _context;
        public RepositoryCliente(ProjetoContext context) : base(context)
        {
            _context = context;
        }
    }
}
