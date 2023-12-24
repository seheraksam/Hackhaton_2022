using Hackathon.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : class,IEntityBase, new()
    {
        List<TEntity> GetAll(params string[] includes);
        TEntity GetById(int id, params string[] includes);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
