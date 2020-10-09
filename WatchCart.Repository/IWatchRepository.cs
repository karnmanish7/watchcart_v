using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Repository
{
   public interface IWatchRepository
    {
        List<Watch> GetWatches(string watchtype, string brandname, string straptype, string strapcolor, string segment);
    }
}
