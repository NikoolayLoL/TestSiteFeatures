using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int? id) // No longer accepts Querry Data ~/categories/edit/135
        {                                              //[FromQuerry] Only from querry ~/categories/edit?id=135
            //var category = new Category { CategoryID = (id.HasValue ? id.Value : 0) };

            var category = CategoriesRepository.GetCategoryByID(id.HasValue ? id.Value : 0);

            return View(category);


            //return id.HasValue ? new ContentResult { Content = id.ToString() } 
            //    : new ContentResult { Content = "Null Content" };

            //Querry String edit?id=555 and URL edit/555 *Same thing!
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoriesRepository.UpdateCategory(category.CategoryID, category);

            //return View(category);

            return RedirectToAction(nameof(Index));
        }
    }
}
