using Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Address")]
    public class Address : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Address>
        {
            public Configuration()
            {
                HasRequired(current => current.User)
                .WithMany(current => current.Addresses)
                .HasForeignKey(current => current.userId)
                .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public Address()
        {

        }
        #endregion
        [Display(Name = "استان")]
        [Required(ErrorMessage = "نام استان را وارد کنید")]
        public string Province { get; set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "نام شهر خود را وارد کنید")]
        public string City { get; set; }
        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "آدرس محل سکونت خود را وارد کنید")]
        public string FullAddress { get; set; }
        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "کد پستی الزامی است !")]
        public string PostalCode { get; set; }

        #region User
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion   

    }
}