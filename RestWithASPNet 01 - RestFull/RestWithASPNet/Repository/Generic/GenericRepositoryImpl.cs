using Microsoft.EntityFrameworkCore;
using RestWithASPNet.Model.Base;
using RestWithASPNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNet.Repository.Generic
{
    public class GenericRepositoryImpl<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        
        //Declarando um dataset generico
        private DbSet<T> dataset;

        public GenericRepositoryImpl(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(item => item.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(items => items.Id.Equals(item.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(people => people.Id.Equals(id));
            try
            {
                if (result != null) dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public bool Exists(long? id)
        {
            return dataset.Any(items => items.Id.Equals(id));
        }
    }
}
