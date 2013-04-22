using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceModels.DTOs;

namespace ServiceModels.ViewModels
{
    /// <summary>
    /// Example ViewModel with pseudo behaviour attached.
    /// 
    /// </summary>
    public class HomeVm
    {
        [ReadOnly(true)]
        public string BrandName { get; set; }
        public string ProductName { get; set; }        
    }

}
