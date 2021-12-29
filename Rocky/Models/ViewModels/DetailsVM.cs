using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {

        }
        public Product Product { get; set; }
        public bool ExcistsInCart { get; set; }
    }
}
