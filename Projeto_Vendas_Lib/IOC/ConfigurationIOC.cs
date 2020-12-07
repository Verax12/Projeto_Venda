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
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();

        }
    }
}
