namespace Challenges.Orders
{
    internal class OrderInProgress : Order
    {
        protected OrderInProgress() { }

        public OrderInProgress(Guid id, string name)
        {
            Id = id;
            Name = name;
            State = OrderState.InProgress;
        }

        public OrderApproved Approve(string approvedBy)
        {
            if (State != OrderState.InProgress)
                throw new Exception("Order has already been modified.");

            State = OrderState.Approved;

            return new OrderApproved(this, approvedBy);
        }

        public OrderRejected Reject(string rejectedBy)
        {
            if (State != OrderState.InProgress)
                throw new Exception("Order has already been modified.");

            State = OrderState.Rejected;

            return new OrderRejected(this, rejectedBy);
        }
    }
}
