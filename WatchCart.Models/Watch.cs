using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models.Constants;

namespace WatchCart.Models
{
    public class Watch
    {
        public Watch()
        {
        }

        public Watch(WatchTypes type)
        {
            this.Type = type;
        }
        public WatchTypes Type { get; set; }
        public int WatchId { get; set; }
        public string BrandName { get; set; }
        public string StrapType { get; set; }
        public string StrapColor { get; set; }
        public string Segment { get; set; }
        public int Price { get; set; }


    }
}
