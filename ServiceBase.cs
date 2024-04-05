using EagleEye.Data;
using EagleEye.Data.Entities.Devices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEye.UI.Web.Core.Services
{
    public abstract class ServiceBase<T, Key> : IServiceBase<T> where T : Data.Entities.Entity<Key>
    {
        public IdentityContext Context { get; set; }
        public DbSet<T> Entity { get; set; }

        public ServiceBase(IdentityContext context)
        {
            this.Context = context;
            if (this.Context != null)
            {
                this.Entity = this.Context.Set<T>();
            }
        }

        public virtual T Delete(T item)
        {
            this.Entity.Remove(item);
            this.Context.SaveChanges();
            return item;
        }

        public virtual T Get(T item)
        {
            return this.Entity.Find(item.Id);
        }

        public virtual IQueryable<T> GetPaging(int start, int length)
        {
            return this.Entity.Skip(start).Take(length);
        }

        public virtual List<T> GetAll()
        {
            return this.Entity.ToList();
        }

        public virtual T Insert(T item)
        {
            this.Entity.Add(item);
            this.Context.SaveChanges();
            return item;
        }

        //public virtual async Task<T> InsertAsync(T item)
        //{
        //    this.Entity.Add(item);
        //    await this.Context.SaveChangesAsync();
        //    return item;
        //}

        public virtual T Update(T item)
        {
            this.Entity.Update(item);
            this.Context.SaveChanges();
            return item;
        }

        protected DbConnection GetConnection()
        {
            var connection = this.Context.Database.GetDbConnection() as DbConnection;
            return connection;
        }
    }
}
