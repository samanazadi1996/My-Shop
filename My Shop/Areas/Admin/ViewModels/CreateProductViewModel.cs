using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.Areas.Admin.ViewModels
{
   public class CreateProductViewModel
    {
        [Display(Name ="دسته بندی")]
        public IEnumerable<Group> groups { get; set; }
        [Display(Name = "محصول")]
        public Product product { get; set; }
    }
}
