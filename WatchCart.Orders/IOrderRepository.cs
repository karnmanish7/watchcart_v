﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Orders
{
    public interface IOrderRepository
    {
        void save(OrderDetails order);
    }
}
