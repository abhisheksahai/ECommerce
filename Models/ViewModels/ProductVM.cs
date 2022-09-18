using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Entities;

namespace Models.ViewModels
{
    public class ProductVM
    {
        public Product ProdDetail { get; set; }

        //[ValidateNever]
        //public IEnumerable<SelectListItem> CategoryList { get; set; }

        //[ValidateNever]
        //public IEnumerable<SelectListItem> SubCategoryList { get; set; }
    }
}