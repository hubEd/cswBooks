using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookEd.Transfer.Repositories
{
    public class MasterRepository : BaseRepository
    {
        public MasterRepository() : base() {}
        public MasterRepository(string env) : base(env) { }

        #region GET ENTITIES
        public T GetSingle<T, D>(Expression<Func<D, bool>> predicate) where D : class
        {
            var data = Context.Set<D>().FirstOrDefault(predicate);
            T result = Mapper.Map<T>(data);
            return result;
        }
        public List<T> GetAll<T, D>(Expression<Func<D, bool>> predicate = null) where D : class
        {
            if (predicate != null)
            {
                var data = Context.Set<D>().Where(predicate).ToList();
                List<T> result = Mapper.Map<List<T>>(data);
                return result;
            }
            else
            {
                var data = Context.Set<D>().ToList();
                List<T> result = Mapper.Map<List<T>>(data);
                return result;
            }
        }
        public bool Exist<D>(Expression<Func<D, bool>> predicate) where D : class
        {
            return Context.Set<D>().Any(predicate);
        }
        #endregion

        #region ADD ENTITIES
        public T Add<T, D>(T transObject) where D : class
        {
            var dataEntity = Mapper.Map<D>(transObject);
            var result = Context.Set<D>().Add(dataEntity);
            Context.SaveChanges();
            return Mapper.Map<T>(result);
        }
        public void UpdateSingle<T, D>(T transObject, Expression<Func<D, bool>> predicate) where D : class
        {
            try
            {
                var dataEntity = Mapper.Map<D>(transObject);
                var dbEntity = Context.Set<D>().FirstOrDefault(predicate);
                Mapper.Map<D, D>(dataEntity, dbEntity);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return;
        }
        #endregion

        #region REMOVE ENTITIES
        public void RemoveSingle<D>(Expression<Func<D, bool>> predicate) where D : class
        {
            var dataEntity = Context.Set<D>().FirstOrDefault(predicate);
            Context.Set<D>().Remove(dataEntity);
        }
        public void RemoveAll<D>(Expression<Func<D, bool>> predicate) where D : class
        {
            var dataEntities = Context.Set<D>().Where(predicate);
            foreach (var entity in dataEntities)
            {
                Context.Set<D>().Remove(entity);
            }
        }
        #endregion
    }
}
