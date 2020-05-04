using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class TicketRepository : IDisposable
    {
        DatabaseContext db = null;

        public TicketRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Ticket entity, bool autoSave = true)
        {
            try
            {
                db.tickets.Add(entity);
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

        public bool Update(Ticket entity, bool autoSave = true)
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

        public bool Delete(Ticket entity, bool autoSave = true)
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
                var entity = db.tickets.Find(id);
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

        public Ticket Find(int id)
        {
            try
            {
                return db.tickets.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ticket> Where(System.Linq.Expressions.Expression<Func<Ticket, bool>> predicate)
        {
            try
            {
                return db.tickets.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Ticket> Select()
        {
            try
            {
                return db.tickets.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Ticket, TResult>> selector)
        {
            try
            {
                return db.tickets.Select(selector);
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
                if (db.tickets.Any())
                    return db.tickets.OrderByDescending(p => p.Id).First().Id;
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

        ~TicketRepository()
        {
            Dispose(false);
        }
    }
}