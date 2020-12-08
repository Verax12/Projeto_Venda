using Microsoft.EntityFrameworkCore;
using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendas_Lib.Repository
{
    public class RepositoryVenda : RepositoryBase<Venda>, IRepositoryVenda
    {
        private readonly ProjetoContext _context;
        public RepositoryVenda(ProjetoContext context) : base(context)
        {
            _context = context;

        }

        public Task<List<Venda>> GetVendaCompleta()
        {
            return _context.Vendas.Include(x => x.Cliente).Include(x => x.Vendedor).Include(x => x.Itens).ToListAsync();
        }

        public Task<Venda> GetVendaCompletaById(Guid id)
        {
            return _context.Vendas.Include(x => x.Cliente).Include(x => x.Vendedor).Include(x => x.Itens).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
