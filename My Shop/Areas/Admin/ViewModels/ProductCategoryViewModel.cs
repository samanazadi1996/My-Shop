using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace My_Shop.Areas.Admin.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Display(Name = "همه محصولات")]
        public IEnumerable<SelectListItem> AllProduct { get; set; }
        [Display(Name = "جدیدترین")]
        public IEnumerable<int> SelectedNewProduct { get; set; }
        [Display(Name = "ویژه")]
        public IEnumerable<int> SelectedSpecial { get; set; }
        [Display(Name = "پرفروش")]
        public IEnumerable<int> SelectedBstSeller { get; set; }
        [Display(Name = "پیشنهادی")]
        public IEnumerable<int> SelectedProposed { get; set; }

    }
}
