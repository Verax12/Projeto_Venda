using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Projeto_Vendas_Lib.IOC
{
    public class ModuleIOC : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IOC
            ConfigurationIOC.Load(builder);
            #endregion
        }
    }
}
