using HDataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HDataAccess.Abstarct
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly HorseContext _context;
        private readonly DbSet<T> table;

        public GenericRepository()
        {
            this._context=new HorseContext();
            table = _context.Set<T>();
        }
        public GenericRepository(HorseContext context, DbSet<T> table)
        {
            _context = context;
            this.table = table;
        }

        public void Add(T item)
        {
            table.Add(item);
        }

        public void Delete(int id)
        {
            T foundedId = table.Find(id);
            if (foundedId==null)
            {
                return;
            }
            table.Remove(foundedId);
            
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
