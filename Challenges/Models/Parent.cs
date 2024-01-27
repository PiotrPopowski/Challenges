using System.Text.Json;

namespace Challenges.Models
{
    internal class Parent
    {
        public int Id { get; set; } = 0;
        public string ToJson() => JsonSerializer.Serialize(this, this.GetType());

        public Parent()
        {
            Id = 100;
        }

        public Parent(int id)
        {
            Id = id;
        }
    }
}
