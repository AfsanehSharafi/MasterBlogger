using _01_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_FrameWork.Infrastructure
{
    public interface IRepository<TKey,T> where T : DomainBase<TKey>
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetList();
        bool Exists(Expression<Func<T,bool>> expression);
    }
}
