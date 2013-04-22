using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.Entities;
using ServiceStack.OrmLite;

namespace IntegrationTests
{
    public class FakeDbFactory
    {
        public static IDbConnectionFactory Create<T>(Product[] products)
        {
            var dbFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteDialect.Provider);

            using (var db = dbFactory.Open())
            {
                db.CreateTable<Product>(overwrite: true);

                db.Insert(products);
            }

            return dbFactory;
        }
    }
}
