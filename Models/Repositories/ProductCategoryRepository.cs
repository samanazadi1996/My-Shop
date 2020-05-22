using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class ProductCategoryRepository : IDisposable
    {
        DatabaseContext db = null;

        public ProductCategoryRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(ProductCategory entity, bool autoSave = true)
        {
            try
            {
                db.productCategories.Add(entity);
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

        public bool Update(ProductCategory entity, bool autoSave = true)
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

        public bool Delete(ProductCategory entity, bool autoSave = true)
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
                var entity = db.productCategories.Find(id);
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

        public ProductCategory Find(int id)
        {
            try
            {
                return db.productCategories.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ProductCategory> Where(System.Linq.Expressions.Expression<Func<ProductCategory, bool>> predicate)
        {
            try
            {
                return db.productCategories.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ProductCategory> Select()
        {
            try
            {
                return db.productCategories.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<ProductCategory, TResult>> selector)
        {
            try
            {
                return db.productCategories.Select(selector);
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
                if (db.productCategories.Any())
                    return db.productCategories.OrderByDescending(p => p.Id).First().Id;
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

        ~ProductCategoryRepository()
        {
            Dispose(false);
        }
    }
}