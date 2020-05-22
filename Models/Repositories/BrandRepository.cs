using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class BrandRepository : IDisposable
    {
        DatabaseContext db = null;

        public BrandRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Brand entity, bool autoSave = true)
        {
            try
            {
                db.brands.Add(entity);
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

        public bool Update(Brand entity, bool autoSave = true)
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

        public bool Delete(Brand entity, bool autoSave = true)
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
                var entity = db.brands.Find(id);
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

        public Brand Find(int id)
        {
            try
            {
                return db.brands.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Brand> Where(System.Linq.Expressions.Expression<Func<Brand, bool>> predicate)
        {
            try
            {
                return db.brands.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Brand> Select()
        {
            try
            {
                return db.brands.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Brand, TResult>> selector)
        {
            try
            {
                return db.brands.Select(selector);
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
                if (db.brands.Any())
                    return db.brands.OrderByDescending(p => p.Id).First().Id;
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

        ~BrandRepository()
        {
            Dispose(false);
        }
    }
}