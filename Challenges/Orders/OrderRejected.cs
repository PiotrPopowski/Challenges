
namespace Challenges.Orders
{
    internal class OrderRejected : Order
    {
        public string rejectedBy;

        public OrderRejected(Order order, string rejectedBy)
            : base(order)
        {
            this.rejectedBy = rejectedBy;
        }
    }
}