using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("User")]
    public class User : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<User>
        {
            public Configuration()
            {

            }
        }
        #endregion /Configuration

        #region Constractor
        public User()
        {
            this.Addresses = new HashSet<Address>();
            this.Products = new HashSet<Product>();
            this.Comments = new HashSet<Comment>();
            this.Orders = new HashSet<Order>();
            this.Tickets = new HashSet<Ticket>();
            this.Sms = new HashSet<Sms>();

        }
        #endregion
        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام خود را وارد کنید")]
        [MinLength(3, ErrorMessage = "نام باید حداقل 3 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "نام باید حداکثر 20 کاراکتر باشد")]
        public string Firstname { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی خود را وارد کنید")]
        [MinLength(3, ErrorMessage = "نام خانوادگی باید حداقل 3 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "نام خانوادگی باید حداکثر 20 کاراکتر باشد")]
        public string Lastname { get; set; }
        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "تاریخ تولد الزامی است")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "جنسیت")]
        public GenderType Gender { get; set; }
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "شماره همراه خود را وارد کنید")]
        [MinLength(10, ErrorMessage = "شماره همراه اشتباه است")]
        public string Phonenumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "رمز عبور خود را وارد کنید")]
        public string Password { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل خود را وارد کنید")]
        [EmailAddress(ErrorMessage ="ایمیل نامعتبر است")]
        public string Email { get; set; }
        [Display(Name = "نقش")]
        public string Roles { get; set; }
        [Display(Name = "وضعیت")]
        public StatusTypeUser Status { get; set; }
        [Display(Name = "خبرنامه")]
        public bool Newsletters { get; set; }
        [Display(Name = "قوانین و مقررات")]
        public bool TermsAndConditions { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Sms> Sms { get; set; }
    }
}