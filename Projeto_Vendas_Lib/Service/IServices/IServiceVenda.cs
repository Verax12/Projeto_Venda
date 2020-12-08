using Projeto_Vendas_Lib.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Vendas_Lib.Service.IServices
{
    public interface IServiceVenda : IServiceBase<Venda>
    {
        Task<List<Venda>> GetVendaCompleta();
        Task<Venda> GetVendaCompletaById(Guid id);
    }
}