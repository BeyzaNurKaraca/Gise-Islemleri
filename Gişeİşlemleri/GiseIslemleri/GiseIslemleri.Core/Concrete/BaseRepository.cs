using GiseIslemleri.Core.Abstract;
using GiseIslemleri.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Core.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly GiseIslemleriContext _context;

        public BaseRepository(GiseIslemleriContext context)
        {
            _context = context;
        }

        public bool Create(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                Set().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T Find(int id)
        {
            return Set().Find(id);
        }



        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return Set().ToList().AsQueryable();
        }
    }
}
