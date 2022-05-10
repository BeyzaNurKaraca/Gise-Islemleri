using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Core.Abstract
{
    public interface IBaseRepository<T> where T : class 
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Find(int id);
        List<T> List();
        DbSet<T> Set();
        IQueryable<T> Get();
    }
}
