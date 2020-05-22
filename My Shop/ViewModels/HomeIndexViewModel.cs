using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Shop.ViewModels
{
    public class HomeIndexViewModel
    {
        [Display(Name = "همه محصولات")]
        public IEnumerable<Product> AllProduct { get; set; }
        [Display(Name = "جدیدترین")]
        public IEnumerable<Product> NewProduct { get; set; }
        [Display(Name = "ویژه")]
        public IEnumerable<Product> Special { get; set; }
        [Display(Name = "ویژه")]
        public IEnumerable<Product> BstSeller { get; set; }
        [Display(Name = "ویژه")]
        public IEnumerable<Product> Proposed { get; set; }
        [Display(Name = "برند ها")]
        public IEnumerable<Brand> brands { get; set; }
        [Display(Name = "بنر اصلی")]
        public IEnumerable<Value> BannerTop { get; set; }
        [Display(Name = "بنر 1 * 1 ")]
        public IEnumerable<Value> Banner1_1 { get; set; }
        [Display(Name = "بنر 2 * 1")]
        public IEnumerable<Value> Banner2_1 { get; set; }
        public bool EnableBanner { get; set; }

    }
}
