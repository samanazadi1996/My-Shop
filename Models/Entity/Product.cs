using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Web.Mvc;

namespace Models
{
    [Table("Product")]
    
    public class Product : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Product>
        {
            public Configuration()
            {
                HasRequired(current => current.User)
                    .WithMany(current => current.Products)
                    .HasForeignKey(current => current.userId)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.Group)
                    .WithMany(current => current.Products)
                    .HasForeignKey(current => current.groupId)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.Brand)
                    .WithMany(current => current.Products)
                    .HasForeignKey(current => current.brandId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public Product()
        {
            this.Comments = new HashSet<Comment>();
            this.ProductFiles = new HashSet<ProductFile>();
            this.Orders = new HashSet<Order>();
            this.ProductCategories = new HashSet<ProductCategory>();

        }
        #endregion
        [AllowHtml]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "برچسپ")]
        public string Caption { get; set; }
        [Display(Name = "قیمت محصول")]
        public Double Price { get; set; }
        [Display(Name = "تخفیف")]
        [Range(0,100)]
        public int Discount { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public int Keyword { get; set; }
        [Display(Name = "تاریخ درج")]
        public DateTime Datetime { get; set; }
        [Display(Name = "وضعیت موجودی")]
        public StatusTypeProduct Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #region User
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion   

        #region Group
        public virtual Group Group { get; set; }
        public int groupId { get; set; }
        #endregion

        #region Brand

        [Display(Name = "برند")]
        public virtual Brand Brand { get; set; }
        public int brandId { get; set; }
        #endregion



    }
}

