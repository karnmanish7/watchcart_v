using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.Service
{
    public class InputValidatorService
    {
        public static int Validate(string input, int limit)
        {
            int inputToInt = Convert.ToInt32(input);
            if (inputToInt > limit)
                return 0;
            else
                return 1;
        }
    }
}
