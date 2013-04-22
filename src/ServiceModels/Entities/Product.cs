using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace ServiceModels.Entities
{
    public interface IEntity
    {
        int Id { get; set; } 
    }

    [Alias("Products")]
    public class Product : IEntity
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string InternalInfo { get; set; } // not for public eyes

        [References(typeof(Brand))]
        public int BrandId { get; set; }
        //public Brand Brand { get; set; }

    }
}
