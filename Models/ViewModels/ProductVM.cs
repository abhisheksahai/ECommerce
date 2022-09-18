using Microsoft.AspNetCore.Http;
using Models.Entities;

namespace Models.ViewModels
{
    public class ProductVM
    {
        public Product ProdDetail { get; set; }

        public IFormFile? FormFile { get; set; } = null;

        //[ValidateNever]
        //public IEnumerable<SelectListItem> CategoryList { get; set; }

        //[ValidateNever]
        //public IEnumerable<SelectListItem> SubCategoryList { get; set; }
    }
}