namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new Queue<string>();

            var newList = list.RemoveEvery(1);
        }

        public struct MyValue
        {
            public int Value { get; set; }
        }
    }
}
