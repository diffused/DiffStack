
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ServiceModels;
using ServiceModels.Entities;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.Common.Extensions;

namespace ServiceInterfaces
{    
    /// <summary>
    /// Start padding this out once Services start duplicating db calls
    /// 
    /// http://stackoverflow.com/questions/14480237/servicestack-ormlite-repository-pattern
    /// 
    /// https://groups.google.com/forum/#!msg/servicestack/1pA41E33QII/R-trWwzYgjEJ
    /// </summary>

    public interface IRepository: IDisposable
    {
        IDbConnectionFactory DbFactory { get; set; }
        IDbConnection Db { get; set; }

        Product ProductById(int id);
        List<Product> PagedProducts(int page, int pageSize);
        
    }


    public class Repository : IRepository
    {
        public IDbConnectionFactory DbFactory { get; set; } //injected

        IDbConnection _db;
        public IDbConnection Db
        {
            get
            {
                if (_db == null)
                    _db = DbFactory.OpenDbConnection();
                return _db;
            }
            set
            {
                _db = value;
            }
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }


        public Product ProductById(int id)
        {
            return Db.First<Product>(a => a.Id == id);
        }

        public List<Product> PagedProducts(int page, int pageSize)
        {
            return (List<Product>)this.Paged<Product>(page, pageSize);
        }

        
    }


    public static class RepositoryExtensions
    {
        public static IEntity SingleById<T>
            (this IRepository repo, int id) where T : IEntity
        {
            return repo.Db.First<T>(a => a.Id == id);
            //using (var db = repo.DbFactory.OpenDbConnection())
            //{
            //    return db.First<T>(a => a.Id == id);
            //}
        }

        /// <summary>
        /// Paged entities. Zero-based
        /// </summary>  
        public static List<T> Paged<T>
            (this IRepository repo, int page, int pageSize) where T : IEntity
        {
            return repo.Db.Select<T>
                (a =>
                    a.OrderByDescending(b => b.Id)
                    .Limit(pageSize * page, pageSize)
                );
        }
    }

    

    
}