
namespace WebApplication1.Models
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
      

        public Ingredient(string id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
