using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    /// <summary>
    /// Asenkron Tasarlanacak
    /// ///Generic Repository
    /// </summary>
    public interface IEntityRepository<T> where T : class,IEntity,new() 
    {
        Task<T> GetAsync(Expression<Func<Random, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); // var kullanici =reposirt.GetAsync(k=k.Id==15);
        ///Expression<Func<Random,bool>> predicate kullanımı:
        ///predicate FİLTRELEME görevi görür. örnek olarak id'si 1 olan kullanici getirmek istiyorsak var kullanici = repository.Get(k=>k.Id==1) gibi. (Linq benzeri kullanımı var)

        /// params Expression<Func<T, object>>[] includeProperties kullanımı:
        /// 25 id'li makaleyi getirirken, makale ile birlikte kullanıcıyı ve yorumlarıda (Birlikte getirmek)include etmek istiyorsak
        /// var makale = repository.GetAsync(m=m.Id==25, m=>m.User, m=>m.Comments) gibi.

        Task<IList<T>> GetAllAsync(Expression<Func<Random, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        //predicate=null gelirse tüm makaleleri çeker, nul gelmezse gelen filtreye göre listeleyeceğiz anlamı taşır.

        Task AddAsync(T entity); 
        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<Random, bool>> predicate);
        Task<int> CountAsync (Expression<Func<Random, bool>> predicate);
    }
}
