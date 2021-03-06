﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Vendas_Lib.Repository.IRepositorys
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);

        T GetById(Guid id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);

        void Dispose();
    }
}
