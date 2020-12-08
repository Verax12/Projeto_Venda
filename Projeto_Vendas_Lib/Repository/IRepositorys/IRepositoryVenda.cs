using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Repository.IRepositorys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Vendas_Lib.Repository
{
    public interface IRepositoryVenda : IRepositoryBase<Venda>
    {
        Task<List<Venda>> GetVendaCompleta();
        Task<Venda> GetVendaCompletaById(Guid id);
    }
}