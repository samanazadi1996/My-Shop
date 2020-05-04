using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class ProductRepository : IDisposable
    {
        DatabaseContext db = null;

        public ProductRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Product entity, bool autoSave = true)
        {
            try
            {
                db.products.Add(entity);
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

        public bool Update(Product entity, bool autoSave = true)
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

        public bool Delete(Product entity, bool autoSave = true)
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
                var entity = db.products.Find(id);
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

        public Product Find(int id)
        {
            try
            {
                return db.products.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Product> Where(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            try
            {
                return db.products.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Product> Select()
        {
            try
            {
                return db.products.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Product, TResult>> selector)
        {
            try
            {
                return db.products.Select(selector);
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
                if (db.products.Any())
                    return db.products.OrderByDescending(p => p.Id).First().Id;
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

        ~ProductRepository()
        {
            Dispose(false);
        }
    }
}