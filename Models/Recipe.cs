
namespace WebApplication1.Models
{
    public class Recipe
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public string BodyText { get; set; }
        public List<String> Steps { get; set; }    
        public List<Ingredient> Ingredients { get; set; }

    }
}
