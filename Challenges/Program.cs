using Challenges.Orders;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = Order.Create(Guid.NewGuid(), "Peter");

            var approved = order.Approve("Tom");

            approved.Cancel("Andrew");

            Console.WriteLine("Order cancelled");
        }
    }
}
