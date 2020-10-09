using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Repository
{
    public interface IWatchCatalog
    {
        List<Watch> Catalog { get; set; }
       
    }
}
