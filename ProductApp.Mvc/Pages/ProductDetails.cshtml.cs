using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApp.Shared.Data;
using ProductApp.Shared.Models;

namespace ProductApp.Mvc.Pages
{
    public class ProductDetailsModel : PageModel
    {
        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = ProductRepository.GetById(id);
        }
    }
}
