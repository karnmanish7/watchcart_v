using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;
using WatchCart.Models.Constants;

namespace WatchCart.Repository
{
    public class WatchCatalog : IWatchCatalog
    {
        public List<Watch> Catalog { get; set; }
        public WatchCatalog()
        {
            this.Catalog = new List<Watch>();
            
        }

       

    }
}
