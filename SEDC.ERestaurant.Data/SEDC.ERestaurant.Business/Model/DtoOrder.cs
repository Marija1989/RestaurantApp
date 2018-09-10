using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Model
{
    public class DtoOrder
    {
        public int OrderId      { get; set; }
        public List<DtoOrderDtoOrderItem> OrderItems { get; set; }
        public double Total { get; set; }
        public string Table{ get; set; }
        public int TotalQuantity { get; set; }



        public DtoOrder() { }
        public DtoOrder(Order order)
        {
            OrderId = order.Id;
            Table = order.Table;
            Total= order.TotalPrice ?? 0;
            TotalQuantity = order.TotalQuantity ?? 0;
            OrderItems = order.Items.Select(oi => new DtoOrderDtoOrderItem(oi)).ToList();
        }


    }

    public class DtoOrderDtoOrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        

        public DtoOrderDtoOrderItem() { }
        public DtoOrderDtoOrderItem(OrderItem oi)
        {
            OrderItemId = oi.OrderItemId;
            OrderId = oi.Orderid;
            ItemId = oi.ItemId;
            Quantity = oi.Quantity;
            
            
        }

    }
}
