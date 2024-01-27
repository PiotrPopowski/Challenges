namespace Challenges.Models
{
    internal class Child : Parent
    {
        public string Name { get; set; }

        public Child(string name)
        {
            Name = name;
        }
    }
}
