
namespace Challenges.Orders
{
    internal class OrderApproved : Order
    {
        public string ApprovedBy { get; init; }

        public OrderApproved(Order order, string approvedBy)
            : base(order)
        {
            ApprovedBy = approvedBy;
        }

        public OrderCancelled Cancel(string cancelledBy)
        {
            if (State != OrderState.Approved)
                throw new Exception("Order has already been modified.");

            State = OrderState.Cancelled;

            return new OrderCancelled(this, cancelledBy);
        }
    }
}