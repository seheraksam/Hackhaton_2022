using Hackathon.DAL.Contexts;
using Hackathon.DAL.Interface;
using Hackathon.Entities.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntityBase, new()
    {
        protected readonly HackathonDbContext _dbContext;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(HackathonDbContext dbContext)
        {
            this._dbContext = dbContext;
            _table = dbContext.Set<TEntity>();

        }

        public void Add(TEntity entity)
        {
            _table.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void Delete(int id)
        {
            var entityToDelete=_table.Where(x => x.Id == id).FirstOrDefault();
            if(entityToDelete!=null)
            _table.Remove(entityToDelete);
        }

        public List<TEntity> GetAll(params string[] includes)
        {
            var query = _table.Where(x => x.IsDeleted == false);
            foreach (var prop in includes)
                query = query.Include(prop);
            return query.ToList();
        }

        public TEntity? GetById(int id, params string[] includes)
        {
            var query = _table.Where(x => x.Id == id);
            foreach (var prop in includes)
                query = query.Include(prop);
            return query.FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
