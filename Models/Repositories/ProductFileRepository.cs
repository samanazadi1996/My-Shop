using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class ProductFileRepository : IDisposable
    {
        DatabaseContext db = null;

        public ProductFileRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(ProductFile entity, bool autoSave = true)
        {
            try
            {
                db.productFiles.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ProductFile entity, bool autoSave = true)
        {
            try
            {

                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(ProductFile entity, bool autoSave = true)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = db.productFiles.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                {
                    return Convert.ToBoolean(db.SaveChanges());
                    ;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public ProductFile Find(int id)
        {
            try
            {
                return db.productFiles.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ProductFile> Where(System.Linq.Expressions.Expression<Func<ProductFile, bool>> predicate)
        {
            try
            {
                return db.productFiles.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ProductFile> Select()
        {
            try
            {
                return db.productFiles.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<ProductFile, TResult>> selector)
        {
            try
            {
                return db.productFiles.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public int GetLastIdentity()
        {
            try
            {
                if (db.productFiles.Any())
                    return db.productFiles.OrderByDescending(p => p.Id).First().Id;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        ~ProductFileRepository()
        {
            Dispose(false);
        }
    }
}