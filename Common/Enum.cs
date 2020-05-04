using System;
using System.Collections.Generic;
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
        VeryBad = -2,
        [Display(Name = "بد")]
        Bad = -1,
        [Display(Name = "")]
        Normal = 0,
        [Display(Name = "خوب")]
        Good = 1,
        [Display(Name = "خیلی خوب")]
        VeryGood = 2
    }
    public enum StatusTypeOrder
    {
        [Display(Name = "درحال پردازش")]
        Processing = 0,
        [Display(Name = "در حال تهیه کالا")]
        Preparation = 1,
        [Display(Name = "منقضی شده")]
        Expired = 2,
        [Display(Name = "ارسال شد")]
        Sent = 3,
        [Display(Name = "تحویل داده شد")]
        Delivered = 4,
    }
}
