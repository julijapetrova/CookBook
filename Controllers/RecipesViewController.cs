using CookBook.DAL;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace CookBook.Controllers
{
    public class RecipesViewController(RecipesDbContext context) : Controller
    {
        private readonly RecipesDbContext recipesDb = context;

        [HttpGet]
        public IActionResult Index()
        {
            return View("./Views/Index.cshtml", recipesDb.Recipes.ToList());
        }

        //GET Recipes/details/name
        [HttpGet("Recipes/Details/Name")]
        public IActionResult Details(string name)
        {
            Recipe r = (Recipe)recipesDb.Recipes.Where(r => r.Name == name);
            return View(r);
        }

        //GET Recipes/details/name
        [HttpGet("Recipes/Delete/Name")]
        public IActionResult Delete(string name)
        {
            if (recipesDb.Recipes.Any(r => r.Name == name))
            {
                if (recipesDb.Recipes.Where(r => r.Name == name) is Recipe n)
                {
                    recipesDb.Recipes.Remove(n);
                }
            }
            return View();
        }
    }
}
