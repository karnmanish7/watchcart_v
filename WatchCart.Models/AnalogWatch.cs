using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Models
{
    public class AnalogWatch :Watch
    {

        public int NumberOfHands { get; set; }
        public bool HasCalender { get; set; }

        public AnalogWatch():base(Constants.WatchTypes.AnalogWatch)
        {

        }
        public override string ToString()
        {
            return string.Format("Model Id: {0}, Brand: {1}, Segment: {2}, Strap Type: {3}, Strap Color: {4}, Price: {5}, Watch Type: {6}, No_Hands: {7}, Calendar: {8} ", this.WatchId,
                this.BrandName, this.Segment, this.StrapType, this.StrapColor, this.Price, "AnalogWatch", this.NumberOfHands, this.HasCalender);
        }

    }
}
