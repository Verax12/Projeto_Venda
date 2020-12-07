using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Repository;
using Projeto_Vendas_Lib.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Service
{
    public class ServiceVendedor : ServicesBase<Vendedor>, IServiceVendedor
    {
        private readonly IRepositoryVendedor _repositoryVendedor;
        public ServiceVendedor(IRepositoryVendedor repositoryVendedor) : base(repositoryVendedor)
        {
            _repositoryVendedor = repositoryVendedor;
        }

    }
}
