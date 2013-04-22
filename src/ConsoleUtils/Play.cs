using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.Entities;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using UnitTests;

namespace ConsoleUtils
{
    class Play
    {
        public void Go()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DiffStack"].ConnectionString;
            var dbFactory = new OrmLiteConnectionFactory(
                connectionString,
                SqlServerDialect.Provider
                );

            using (var Db = dbFactory.OpenDbConnection())
            {
                var ids = new int[] { 1, 2, 3, 4, 5 };
                //var ids = new List<int> { 1, 2, 3 };
                var products = Db.Select<Product>(p => Sql.In(p.Id, ids));
                //var products = Db.Select<Product>();

                products.PrintDump();
            }
        }
    }
}
