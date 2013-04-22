using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace ServiceModels.Entities
{
    [Alias("Brands")]
    public class Brand
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Index(Unique=true)]
        public string Name { get; set; }
        public string LogoFile { get; set; }
    }
}
