using CookBook.DAL;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController(RecipesDbContext context) : Controller
    {

        private readonly RecipesDbContext recipesDb = context;

        //public static List<Recipe> TestRecipes =
        //[
        //    new Recipe(){
        //        Name="Sushi",
        //        Ingredients= [
        //             new Ingredient("1","rice") { },
        //             new Ingredient("2","salmon") { },
        //             new Ingredient("3","wasabi") { },
        //             new Ingredient("4","salt") { }
        //            ]},
        //    new Recipe(){
        //        Name="Chocolate Cake" ,
        //        Ingredients= [
        //            new Ingredient("4","salt") { },
        //            new Ingredient("5","eggs") { },
        //            new Ingredient("6","chocolate") { },
        //            new Ingredient("7","flour") { }
        //            ]}];

      
        [HttpGet("All")]
        public IEnumerable<Recipe> Get()
        {
            return recipesDb.Recipes;
        }
        [HttpGet("ByName")]
        public Recipe Get(string name)
        {
            return (Recipe)recipesDb.Recipes.Where(r => r.Name == name);
        }
      
      
        [HttpPost("Add")]
        public void Post(Recipe recipe)
        {

            recipesDb.Add(new Recipe()
            {
                Name = "Fish and Chips",
            });


            if (!recipesDb.Recipes.Any(r => r.Name == recipe.Name))
            {
                recipesDb.Recipes.Add(recipe);
            };
            recipesDb.SaveChanges();

        }
        [HttpDelete("Delete")]
        public void Delete(Recipe recipe)
        {
            var recipeToDelete = recipesDb.Recipes.FirstOrDefault(r => r.Name == recipe.Name);
            if (recipeToDelete != null)
            {
                recipesDb.Recipes.Remove(recipeToDelete);
                recipesDb.SaveChanges();
            }
        }
        [HttpPut("Edit/Recipe")]
        public void EditRecipe(string name, Recipe recipe)
        {
            Recipe fromRecipe = recipesDb.Recipes.First(r => r.Name == name);
            Recipe toRecipe = recipe;
            if (recipesDb.Recipes.Contains(fromRecipe))
            {
                recipesDb.Recipes.Remove(fromRecipe);
                recipesDb.Recipes.Add(new Recipe()
                {
                    Name = toRecipe.Name != null && toRecipe.Name != "string" ? toRecipe.Name : fromRecipe.Name,
                    BodyText = toRecipe.BodyText != null && toRecipe.BodyText != "string" ? toRecipe.BodyText : fromRecipe.BodyText,
                    Ingredients = toRecipe.Ingredients,    //FIX so it checks if the theres anything in the new list and adds it to the old
                    Steps = toRecipe.Steps,   //FIX
                });
            }
        }

        [HttpPut("Edit/Ingredients")]
        public void EditIngredients(string name, List<Ingredient> ingredients)
        {
            Recipe recipe = recipesDb.Recipes.First(r => r.Name == name);
            if (recipe != null)
            {
                recipe.Ingredients = ingredients;
            }

        }
        [HttpPut("Edit/Steps")]
        public void EditSteps(string name, List<string> steps)
        {
            Recipe recipe = recipesDb.Recipes.First(r => r.Name == name);
            if (recipe != null)
            {
                recipe.Steps = steps;
            }

        }
    }
}
/*
 Build a Recipe Box
Objective: Build an app that is functionally similar to this: https://codepen.io/freeCodeCamp/full/dNVazZ/.

Fulfill the below user stories and get all of the tests to pass. Use whichever libraries or APIs you need. Give it your own personal style.

User Story: I can create recipes that have names and ingredients.

User Story: I can see an index view where the names of all the recipes are visible.

User Story: I can click into any of those recipes to view it.

User Story: I can edit these recipes.

User Story: I can delete these recipes.

User Story: All new recipes I add are saved in my browser's local storage. If I refresh the page, these recipes will still be there.

Hint: You should prefix your local storage keys on CodePen, i.e. _username_recipes

When you are finished, include a link to your project on CodePen and click the "I've completed this challenge" button.

You can get feedback on your project by sharing it on the freeCodeCamp forum.


 */

/*
  using (var db = new BloggingContext())
        {
            // Create
            Console.WriteLine("Inserting a new blog");
            db.Blogs.Add(new Blog { Url = "http://sample.com" });
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a blog");
            var blog = db.Blogs
                .OrderBy(b => b.BlogId)
                .First();

            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "http://sample123.com";
            blog.Posts.Add(new Post { Title = "Hello World", Content = "My first post" });
            db.SaveChanges();

            // Delete
            Console.WriteLine("Delete the blog");
            db.Remove(blog);
            db.SaveChanges();
        }
 */