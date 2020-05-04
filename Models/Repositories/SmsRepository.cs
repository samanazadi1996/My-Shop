using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class SmsRepository : IDisposable
    {
        DatabaseContext db = null;

        public SmsRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Sms entity, bool autoSave = true)
        {
            try
            {
                db.sms.Add(entity);
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

        public bool Update(Sms entity, bool autoSave = true)
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

        public bool Delete(Sms entity, bool autoSave = true)
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
                var entity = db.sms.Find(id);
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

        public Sms Find(int id)
        {
            try
            {
                return db.sms.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Sms> Where(System.Linq.Expressions.Expression<Func<Sms, bool>> predicate)
        {
            try
            {
                return db.sms.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Sms> Select()
        {
            try
            {
                return db.sms.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Sms, TResult>> selector)
        {
            try
            {
                return db.sms.Select(selector);
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
                if (db.sms.Any())
                    return db.sms.OrderByDescending(p => p.Id).First().Id;
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

        ~SmsRepository()
        {
            Dispose(false);
        }
    }
}