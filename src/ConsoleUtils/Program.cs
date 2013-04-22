using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.Entities;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using UnitTests;

namespace ConsoleUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            new Setup().Db();

            "Db created".Print();
        }


    }
        

    class Setup
    {
        IDbConnection _db;

        public void Db()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DiffStack"].ConnectionString;
            var dbFactory = new OrmLiteConnectionFactory(
                connectionString,
                SqlServerDialect.Provider
                );

            using (_db = dbFactory.OpenDbConnection())
            {
                setupTables();
                seed();
                print();
            }

        }

        private void setupTables()
        {
            "drop/create tables...".Print();

            _db.DropTables(typeof(Product), typeof(Brand));
            
            _db.CreateTable<Brand>();
            _db.CreateTable<Product>();
        }


        private void seed()
        {
            "seeding...".Print();

            3.Times(i => _db.Insert<Brand>(new Brand { Name = "Brand " + (i + 1) }));

            30.Times(i => _db.Insert<Product>(
                new Product
                {
                    Name = "Product " + (i + 1),
                    InternalInfo = "secret biz stuff for product " + (i + 1),
                    BrandId = (i % 3)+1
                }
            ));
        }

        void print()
        {
            //_db.First<Brand>(p => p.Id == 1).PrintDump();


            //var product1 = _db.First<Product>(p => p.Id == 1);
            
            //product1.PrintDump();
            //product1.Brand.PrintDump();

            _db.Select<Brand>().PrintDump();
            _db.Select<Product>().PrintDump();
        }



    }




}
