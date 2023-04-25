using BLL.Interface;
using BLL.Repository;
using DAL.Data;
using DAL.Entities;
using System.Collections;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.DAL.Data;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repostories;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();

        public IGenericRepo<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repostories == null) _repostories = new Hashtable();

            var type = typeof(TEntity).Name;

            if(!_repostories.ContainsKey(type))
            {
                var repository = new GenericRepo<TEntity>(_context);
                _repostories.Add(type, repository);
            }

            return (IGenericRepo<TEntity>) _repostories[type];
        }

    }
}
