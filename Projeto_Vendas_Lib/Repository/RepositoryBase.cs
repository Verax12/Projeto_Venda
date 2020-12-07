using Microsoft.EntityFrameworkCore;
using Projeto_Vendas_Lib.Infra.Context;
using Projeto_Vendas_Lib.Repository.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Vendas_Lib.Repository
{
 
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private readonly ProjetoContext _context;

        public RepositoryBase(ProjetoContext context)
        {
            _context = context;
        }

        /// Verifico se foi salvo com sucesso
        public virtual void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }


        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
