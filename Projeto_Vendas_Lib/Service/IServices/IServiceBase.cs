using System.Collections.Generic;

namespace Projeto_Vendas_Lib.Service
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}