using SEDC.ERestaurant.Business.Model;
using SEDC.ERestaurant.Data.Model;
using SEDC.ERestaurant.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Service
{
    public class OrderService : BaseService<OrderRepository>
    {

        public ServiceResult<DtoOrder> CreateOrder(DtoOrder order)
        {
            using (var transaction = Repository.DbContext.Database.BeginTransaction())
            {
                try
                {
                    var newOrder = new Order
                    {
                        Id = 0,
                        StatusOfOrder = (byte)Status.Created,
                        Table = order.Table,
                        DateCreated = DateTime.UtcNow
                    };
                    DbContext.Orders.Add(newOrder);
                    DbContext.SaveChanges();
                    DbContext.OrderItems.AddRange(order.OrderItems.Select(o => new OrderItem
                    {
                        OrderItemId = 0,
                        ItemId = o.ItemId,
                        Orderid = newOrder.Id,
                        Quantity = (short)o.Quantity
                    }));
                    transaction.Commit();
                    transaction.Commit();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = true,
                        Item = new DtoOrder(newOrder)

                    };
                }


                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = false,
                        Exception = ex,
                        ErrorMessage = "an exception occurred"
                    };
                }


            }
        }


        public ServiceResult<DtoOrder> EditOrder(DtoOrder order)
        {

            try
            {
                if (order == null)
                {
                    return new ServiceResult<DtoOrder>
                    {
                        Success = false,
                        Exception = new ArgumentNullException("order")
                    };
                }
                var dbOrder = Repository.DbContext.Orders.FirstOrDefault(x => x.Id == order.OrderId);

                if (dbOrder == null)
                {
                    return new ServiceResult<DtoOrder>
                    {
                        Success = false,
                        ErrorMessage = "3404"
                    };
                }
                dbOrder.Table = order.Table;
                DbContext.SaveChanges();
                return new ServiceResult<DtoOrder>
                {
                    Success = true,
                    Item = new DtoOrder(dbOrder)
                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ""
                };
            }





        }


        public ServiceResult<DtoOrderDtoOrderItem> AddOrderItemToOrder(DtoOrderDtoOrderItem orderItem)
        {


            try
            {


                var orderExist = DbContext.Orders.SingleOrDefault(x => x.Id == orderItem.OrderId);
                var itemExist = DbContext.Items.SingleOrDefault(x => x.Id == orderItem.ItemId);
                var orderItemExist = DbContext.OrderItems.SingleOrDefault(x => x.OrderItemId == orderItem.OrderItemId);

                if (orderItem == null)
                {
                    return new ServiceResult<DtoOrderDtoOrderItem>
                    {
                        Success = false,
                        ErrorMessage = "Order item is empty!",
                        Exception = new ArgumentNullException("orderItem")
                    };
                }

                if (orderExist == null || itemExist == null)
                {
                    throw new Exception("Item or order doesn't exist in database!");
                }


                if (orderItemExist == null)
               {

                     if (orderItem.Quantity > 0)
                     {
                            var newOrderItem = new OrderItem()
                            {
                                Orderid = orderItem.OrderId,
                                ItemId = orderItem.ItemId,
                                Quantity = (short)orderItem.Quantity
                            };
                            DbContext.OrderItems.Add(newOrderItem);
                            DbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("order item must have valid number");
                    }
              }

             else
             {
                    


                    if (orderItem.Quantity > 0)
                    {
                       
                        orderItemExist.Quantity = (short)orderItem.Quantity;
                        DbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Quantity must be a positive number!");
                    }


                }

                  
                return new ServiceResult<DtoOrderDtoOrderItem>
                {
                    Success = true,
                    
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<DtoOrderDtoOrderItem>
                {
                    Success = false,
                    ErrorMessage = "",
                };
            }




        }



    }
}

