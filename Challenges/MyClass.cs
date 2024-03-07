
namespace Challenges
{
    internal class MyClass<T> where T : class
    {
        public Dictionary<string, string> dic { get; set; } = new Dictionary<string, string>();
        public T Value { get; }

        public MyClass(T value)
        {
            Value = value;
        }
    }
}
