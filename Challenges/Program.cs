using Challenges.Models;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var child = new Child("Tom");
            Console.WriteLine("Object: {0}. Type: {1}", child.ToJson(), child.GetType());

            Parent childParent = new Child("Tom");
            Console.WriteLine("Object: {0}. Type: {1}", childParent.ToJson(), childParent.GetType());

            Parent parent = new Parent();
            Console.WriteLine("Object: {0}. Type: {1}", parent.ToJson(), parent.GetType());
        }
    }
}
