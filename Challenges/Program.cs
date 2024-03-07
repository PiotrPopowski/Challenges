using System.Text.Json;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass<string> mc = new MyClass<string>("Hi");

            mc.dic["key"] = "value";

            var json =  JsonSerializer.Serialize(mc);

            var newDic = JsonSerializer.Deserialize<MyClass<string>>(json);
        }
    }
}
