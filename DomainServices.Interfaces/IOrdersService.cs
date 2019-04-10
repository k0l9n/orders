using DataTransferObjects.Orders;

namespace DomainServices.Interfaces
{
    public interface IOrdersService
    {
        OrderDto[] GetOrders();
    }
}
