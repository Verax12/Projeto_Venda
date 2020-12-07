using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Service
{
    public class ServiceItem : ServicesBase<Item>, IServiceItem
    {
        private readonly IRepositoryItem _repositoryItem;
        public ServiceItem(IRepositoryItem repositoryItem) : base(repositoryItem)
        {
            _repositoryItem = repositoryItem;
        }
    }
}
