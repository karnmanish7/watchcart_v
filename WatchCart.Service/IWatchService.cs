using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Service
{
    public interface IWatchService 
    {
        Watch GetWatches(int watchType, int brandName, int straptype, int strapcolor, int segment);
    }
}
