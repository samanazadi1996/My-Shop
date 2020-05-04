using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class OrderRepository : IDisposable
    {
        DatabaseContext db = null;

        public OrderRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Order entity, bool autoSave = true)
        {
            try
            {
                db.orders.Add(entity);
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

        public bool Update(Order entity, bool autoSave = true)
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

        public bool Delete(Order entity, bool autoSave = true)
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
                var entity = db.orders.Find(id);
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

        public Order Find(int id)
        {
            try
            {
                return db.orders.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Order> Where(System.Linq.Expressions.Expression<Func<Order, bool>> predicate)
        {
            try
            {
                return db.orders.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Order> Select()
        {
            try
            {
                return db.orders.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Order, TResult>> selector)
        {
            try
            {
                return db.orders.Select(selector);
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
                if (db.orders.Any())
                    return db.orders.OrderByDescending(p => p.Id).First().Id;
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

        ~OrderRepository()
        {
            Dispose(false);
        }
    }
}