using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

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
            }
        }
        #endregion /Configuration

        #region Constractor
        public Product()
        {
            this.Comments = new HashSet<Comment>();
            this.ProductFiles = new HashSet<ProductFile>();
            this.Orders = new HashSet<Order>();

        }
        #endregion

        public string Description { get; set; }
        public string Caption { get; set; }
        public Double Price { get; set; }
        public int Discount { get; set; }
        public DateTime Datetime { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #region User
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion   

        #region Group
        public virtual Group Group { get; set; }
        public int groupId { get; set; }
        #endregion


    }
}

