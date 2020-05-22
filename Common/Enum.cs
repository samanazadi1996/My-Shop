using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum GenderType
    {
        [Display(Name = "نامشخص")]
        Unknow = 0,
        [Display(Name = "مرد")]
        Mele = 1,
        [Display(Name = "زن")]
        Femele = 2
    }
    public enum StatusTypeUser
    {
        [Display(Name = "نامشخص")]
        Unknow = 0,
        [Display(Name = "فعال")]
        Active = 1,
        [Display(Name = "غیرفعال")]
        Blocked = 2
    }
    public enum RateType
    {
        [Display(Name = "خیلی بد")]
        VeryBad = 1,
        [Display(Name = "بد")]
        Bad = 2,
        [Display(Name = "")]
        Normal = 3,
        [Display(Name = "خوب")]
        Good = 4,
        [Display(Name = "خیلی خوب")]
        VeryGood = 5
    }
    public enum StatusTypeOrder
    {
        [Display(Name = "درحال پردازش")]
        Processing = 0,
        [Display(Name = "در حال تهیه کالا")]
        Preparation = 1,
        [Display(Name = "ارسال شد")]
        Sent = 2,
        [Display(Name = "تحویل داده شد")]
        Delivered = 3,
        [Display(Name = "منقضی شده")]
        Expired = 4,

    }
    public enum StatusTypeProduct
    {
        [Display(Name = "موجود")]
        Existing = 1,
        [Display(Name = "نا موجود")]
        NonExisting = 0,

    }
    public enum ProductCategoryType
    {
        [Display(Name = "ویژه")]
        SpecialProduct = 1,
        [Display(Name = "جدیدترین")]
        NewProduct = 2,
        [Display(Name = "پرفروش")]
        BestSellerProduct = 3,
        [Display(Name = "پیشنهادی")]
        ProposedProduct = 4,

    }
}



