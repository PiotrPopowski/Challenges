namespace Challenges.Orders
{
    internal abstract class Order
    {
        protected Order(Order order)
        {
            Id = order.Id;
            Name = order.Name;
            State = order.State;
        }

        public Order() {}

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public OrderState State { get; protected set; }

        public static OrderInProgress Create(Guid id, string name)
        {
            return new OrderInProgress(id, name);
        }
    }

    public enum OrderState
    {
        InProgress,
        Approved,
        Rejected,
        Cancelled
    }
}
