using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Orders
{
    public class WatchStoreDbContext : DbContext
    {
        public WatchStoreDbContext():base("watchCartString")
        {

        }
        public DbSet<OrderDetails> OrderDetail { get; set; }
        public DbSet<Watch> WatchDetail { get; set; }//require if we want to store watch details dynamically in future
    }
}
