using DataTransferObjects.Orders;
using DomainServices.Interfaces;
using Repositories;
using StoreDbContext.Entities;
using System.Linq;

namespace DomainServices
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> _ordersRepository;

        public OrdersService(IRepository<Order> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public OrderDto[] GetOrders()
        {
            return _ordersRepository.GetAll().ToArray().Select(CreateOrderDto).ToArray();
        }

        private static OrderDto CreateOrderDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                OxId = order.OxId,
                OrderDate = order.OrderDate,
                AddressId = order.AddressId,
                StateId = order.StateId,
                InvoiceNumber = order.InvoiceNumber,
                ArticleIds = order.OrdersToArticles.Select(x => x.ArticleId).ToArray()
            };
        }
    }
}
