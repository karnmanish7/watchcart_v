using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Models
{
    public class DigitalWatch : Watch
    {
        public DigitalWatch(): base(Constants.WatchTypes.DigitalWatch)
        {

        }
        public string DisplayMode { get; set; }
        public bool HasBackLight { get; set; }

        public override string ToString()
        {
            return string.Format("Model Id: {0}, Brand: {1}, Segment: {2}, Strap Type: {3}, Strap Color: {4}, Price: {5}, Watch Type: {6}, DisplayMode: {7}, BackLight: {8} ", this.WatchId,
                this.BrandName, this.Segment, this.StrapType, this.StrapColor, this.Price, "DigitalWatch", this.DisplayMode, this.HasBackLight);
        }

    }
}
