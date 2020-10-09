using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private WatchStoreDbContext _watchStoreDb;

        public OrderRepository(WatchStoreDbContext dbContext)
        {
            this._watchStoreDb = dbContext;
        }

        

        public void save(OrderDetails order)
        {
            this._watchStoreDb.OrderDetail.Add(order);
            this._watchStoreDb.SaveChanges();
        }
    }
}
