using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Repository
{
    public class WatchRepository: IWatchRepository
    {
        public IWatchCatalog WatchCatalog { get; set; }

        public WatchRepository(IWatchCatalog watchCatalog)
        {
            this.WatchCatalog = watchCatalog;
        }

        public List<Watch> GetWatches(string watchtype, string brandname, string straptype, string strapcolor, string segment)
        {
            List<Watch> matchedWatches = new List<Watch>();
            foreach (var item in WatchCatalog.Catalog)
            {
                if(item.Type.ToString()==watchtype && item.BrandName==brandname && item.StrapType==straptype && item.StrapColor==strapcolor && item.Segment == segment)
                {
                    matchedWatches.Add(item);
                }
            }

            Console.WriteLine("*********************************************");
            Console.WriteLine("Your matched combination to process order is:");

            return matchedWatches;
        }
    }
}
