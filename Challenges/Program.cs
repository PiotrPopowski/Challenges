namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActionRunner ar = new ActionRunner();

            ar.Run();
            Task.Delay(1200).Wait();

            Console.WriteLine("Hey there.");
        }
    }
}
