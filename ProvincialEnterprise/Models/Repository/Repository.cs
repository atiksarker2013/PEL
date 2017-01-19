using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class Repository<T> where T: class 
    {
        PELEntities dbContext = new PELEntities();

        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            DbSet = dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public void GetProcedure(T entity)
        {
            DbSet.Remove(entity);         
        }
    }
}