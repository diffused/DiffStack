using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceInterface;

namespace ServiceInterfaces
{
    /// <summary>    
    /// </summary>
    public class BaseService : Service
    {
        public IRepository Repository { get; set; }

        ///// <summary>
        ///// Replaces base.Db with our injected IRepository.IDbConnection                
        ///// </summary>
        //public override IDbConnection Db
        //{
        //    get
        //    {
        //        return Repository.Db;
        //    }
        //}
    }
}
