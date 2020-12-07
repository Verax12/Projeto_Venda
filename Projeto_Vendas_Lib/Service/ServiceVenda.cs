using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Service
{
    public class ServiceVenda : ServicesBase<Venda>, IServiceVenda
    {
        private readonly IRepositoryVenda _repositoryVenda;
        public ServiceVenda(IRepositoryVenda repositoryVenda) : base(repositoryVenda)
        {
            _repositoryVenda = repositoryVenda;
        }

    }
}
