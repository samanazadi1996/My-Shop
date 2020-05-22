using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class AddressRepository : IDisposable
    {
        DatabaseContext db = null;

        public AddressRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Address entity, bool autoSave = true)
        {
            try
            {
                db.addresses.Add(entity);
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

        public bool Update(Address entity, bool autoSave = true)
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

        public bool Delete(Address entity, bool autoSave = true)
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
                var entity = db.addresses.Find(id);
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

        public Address Find(int id)
        {
            try
            {
                return db.addresses.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Address> Where(System.Linq.Expressions.Expression<Func<Address, bool>> predicate)
        {
            try
            {
                return db.addresses.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Address> Select()
        {
            try
            {
                return db.addresses.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Address, TResult>> selector)
        {
            try
            {
                return db.addresses.Select(selector);
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
                if (db.addresses.Any())
                    return db.addresses.OrderByDescending(p => p.Id).First().Id;
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

        ~AddressRepository()
        {
            Dispose(false);
        }
    }
}