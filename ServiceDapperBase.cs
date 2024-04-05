using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEye.UI.Web.Core.Services
{
    public abstract class ServiceDapperBase<T, Key> : IServiceBase<T> where T : Data.Entities.Entity<Key>
    {
        protected readonly IConfiguration _configuration;

        public abstract T Delete(T item);
        public abstract T Get(T item);
        public abstract List<T> GetAll();
        public abstract T Insert(T item);

        public abstract IQueryable<T> GetPaging(int start, int length);
        //public virtual async Task<T> InsertAsync(T item)
        //{
        //    await Task.Delay(0);
        //    var task = Task.Factory.StartNew(() => {
        //        return this.Insert(item);
        //    });

        //    return task.Result;
        //}
        public abstract T Update(T item);

        public ServiceDapperBase(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected SqlConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
