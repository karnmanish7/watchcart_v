using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;
using WatchCart.Models.Constants;
using WatchCart.Repository;

namespace WatchCart.Service
{
    public class WatchService : IWatchService
    {

        public WatchService(IWatchRepository watchRepository)
        {
            this.WatchRepository = watchRepository;
        }

        public IWatchRepository WatchRepository { get; }

        public Watch GetWatches(int watchType, int brandName, int straptype, int strapcolor, int segment)
        {
            try
            {
                var x = Enum.ToObject(typeof(StrapType), straptype).ToString();
                return this.WatchRepository.GetWatches(

                     Enum.ToObject(typeof(WatchTypes), watchType).ToString(),
                     Enum.ToObject(typeof(BrandName), brandName).ToString(),
                     Enum.ToObject(typeof(StrapType), straptype).ToString(),
                     Enum.ToObject(typeof(StrapColor), strapcolor).ToString(),
                     Enum.ToObject(typeof(Segment), segment).ToString()

                                                 ).First();
            }
            catch(Exception ex)
            {
                throw new NoMatchFoundException("No Match Found, Please Try Another Combination");
            }

        }
    }
}
