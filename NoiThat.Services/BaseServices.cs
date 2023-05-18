using NoiThat.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services
{
    
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        IBaseResponsitory<TEntity> _responsitory;

        public BaseServices(IBaseResponsitory<TEntity> responsitory)
        {
            _responsitory = responsitory;
        }

        public async Task<TEntity> Add(TEntity obj)
        {
          return  await _responsitory.Add(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _responsitory.GetAll();
        }

        public async Task<TEntity> GetById(string id)
        {
           return await _responsitory.GetById(id);
        }

        public async Task<bool> Remove(string id)
        {
            return await _responsitory.Remove(id);
        }

        public async Task<TEntity> Update(string id, TEntity obj)
        {
            return await _responsitory.Update(id, obj);
        }
    }
}
