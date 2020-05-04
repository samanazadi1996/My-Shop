using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Order>
        {
            public Configuration()
            {
                HasRequired(current => current.User)
                    .WithMany(current => current.Orders)
                    .HasForeignKey(current => current.userId)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.Product)
                    .WithMany(current => current.Orders)
                    .HasForeignKey(current => current.productId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public Order()
        {

        }
        #endregion

        public string Description { get; set; }
        public int Count { get; set; }
        public DateTime Datetime { get; set; }
        public double Price { get; set; }
        public StatusTypeOrder status { get; set; }

        #region User
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion

        #region Product
        public virtual Product Product { get; set; }
        public int productId { get; set; }
        #endregion


    }
}

