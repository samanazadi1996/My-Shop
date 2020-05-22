using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Web.Mvc;

namespace Models
{
    [Table("ProductCategory")]
    
    public class ProductCategory : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<ProductCategory>
        {
            public Configuration()
            {

                HasRequired(current => current.Product)
                    .WithMany(current => current.ProductCategories)
                    .HasForeignKey(current => current.productId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public ProductCategory()
        {
        }
        #endregion
        public ProductCategoryType ProductType { get; set; }

        #region Product
        public virtual Product Product { get; set; }
        public int productId { get; set; }
        #endregion



    }
}

