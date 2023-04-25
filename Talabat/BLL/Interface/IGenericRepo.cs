using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Talabat.BLL.Specifications;

namespace BLL.Interface
{
    public interface IGenericRepo<T>
    {
        Task<T> GetByIdAsync(int id);
        
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        Task<int> GetCountAsync(ISpecification<T> spec);

        //Task<Comment> GetById(int id);
        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
