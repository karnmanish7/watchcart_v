using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Models.Constants
{
    public enum WatchTypes
    {
        [Description("AnalogWatch")]
        AnalogWatch=1,
        [Description("DigitalWatch")]
        DigitalWatch=2
    }
}
