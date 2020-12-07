using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Repository.IRepositorys;
using Projeto_Vendas_Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Service
{
    public class ServiceCliente : ServicesBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente _repositoryCliente;
        public ServiceCliente(IRepositoryCliente repositoryCliente) : base(repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }
    }
}
