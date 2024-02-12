using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace GoGIS_Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GoGISAppContext _context;
        private System.Data.Entity.IDbSet<T> _entities;
        GoGISAppContext context = new GoGISAppContext();

        #region CTor

        public Repository()
        {
            this._context = context;
        }

        #endregion

        #region Methods

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return this.Entities;
        }

        public T GetById(object Id)
        {
            return this.Entities.Find(Id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                this.Entities.Remove(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }

        public IEnumerable<T> Table
        {
            get { return this.Entities; }
        }
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        public long InsertAndGetId(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                this._context.SaveChanges();

                return entity.Id;
            }
            catch (DbEntityValidationException dbex)
            {
                throw new Exception(dbex.Message);
            }
        }
        #endregion
    }
}
