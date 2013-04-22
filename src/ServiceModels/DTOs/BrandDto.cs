using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;

namespace ServiceModels.DTOs
{
    [Route("/brands")]
    public class BrandDto : IReturn<BrandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
