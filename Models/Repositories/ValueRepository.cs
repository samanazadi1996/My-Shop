﻿using System;
using System.Linq;
using System.Web;

namespace Models.Repositories
{
    public class ValueRepository : IDisposable
    {
        DatabaseContext db = null;

        public ValueRepository()
        {
            db = new DatabaseContext();
        }

        public bool Add(Value entity, bool autoSave = true)
        {
            try
            {
                db.values.Add(entity);
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

        public bool Update(Value entity, bool autoSave = true)
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

        public bool Delete(Value entity, bool autoSave = true)
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
                var entity = db.values.Find(id);
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

        public Value Find(int id)
        {
            try
            {
                return db.values.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Value> Where(System.Linq.Expressions.Expression<Func<Value, bool>> predicate)
        {
            try
            {
                return db.values.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Value> Select()
        {
            try
            {
                return db.values.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Value, TResult>> selector)
        {
            try
            {
                return db.values.Select(selector);
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
                if (db.values.Any())
                    return db.values.OrderByDescending(p => p.Id).First().Id;
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

        ~ValueRepository()
        {
            Dispose(false);
        }
    }
}