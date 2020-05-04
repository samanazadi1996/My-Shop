using Common;
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
        [Required(ErrorMessage = "نام خود را وارد کنید")]
        [MinLength(3, ErrorMessage = "نام باید حداقل 3 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "نام باید حداکثر 20 کاراکتر باشد")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "نام خانوادیگی خود را وارد کنید")]
        [MinLength(3, ErrorMessage = "نام خانوادگی باید حداقل 3 کاراکتر باشد")]
        [MaxLength(20, ErrorMessage = "نام خانوادگی باید حداکثر 20 کاراکتر باشد")]

        public string Lastname { get; set; }
        [Required(ErrorMessage = "سن خود را وارد کنید")]
        public int Age { get; set; }

        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "شماره تماس خود را وارد کنید")]
        [MinLength(11, ErrorMessage = "شماره تلفن باید حداقل 11 کاراکتر باشد")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "رمز عبور خود را وارد کنید")]
        public string Password { get; set; }
        public string Email { get; set; }
        public StatusTypeUser Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Sms> Sms { get; set; }
    }
}