using Autofac;
using Projeto_Vendas_Lib.Repository;
using Projeto_Vendas_Lib.Repository.IRepositorys;
using Projeto_Vendas_Lib.Service;
using Projeto_Vendas_Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.IOC
{

    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Repositorys

            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryVenda>().As<IRepositoryVenda>();
            builder.RegisterType<RepositoryItens>().As<IRepositoryItem>();
            builder.RegisterType<RepositoryVendedor>().As<IRepositoryVendedor>();

            #endregion

            #region Services

            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceVenda>().As<IServiceVenda>();
            builder.RegisterType<ServiceItem>().As<IServiceItem>();
            builder.RegisterType<ServiceVendedor>().As<IServiceVendedor>();

            #endregion
        }
    }
}
