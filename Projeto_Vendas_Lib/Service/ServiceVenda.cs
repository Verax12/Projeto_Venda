using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Repository;
using Projeto_Vendas_Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Vendas_Lib.Service
{
    public class ServiceVenda : ServicesBase<Venda>, IServiceVenda
    {
        private readonly IRepositoryVenda _repositoryVenda;
        public ServiceVenda(IRepositoryVenda repositoryVenda) : base(repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }
        public Task<List<Venda>> GetVendaCompleta()
        {
            return _repositoryVenda.GetVendaCompleta();
        }
        public Task<Venda> GetVendaCompletaById(Guid id)
        {
            return _repositoryVenda.GetVendaCompletaById(id);
        }


    }
}
