using Microsoft.AspNetCore.Mvc;
using lr9.Models;

namespace lr9.ViewComponents
{
    public class ProductTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Product> products)
        {
            return View(products);
        }
    }
}