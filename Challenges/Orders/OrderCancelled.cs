namespace Challenges.Orders
{
    internal class OrderCancelled : Order
    {
        public string CancelledBy { get; }

        public OrderCancelled(Order order, string cancelledBy)
            : base(order)
        {
            this.CancelledBy = cancelledBy;
        }
    }
}