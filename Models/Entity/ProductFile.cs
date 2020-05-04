using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("ProductFile")]
    public class ProductFile : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<ProductFile>
        {
            public Configuration()
            {
                HasRequired(current => current.Product)
                    .WithMany(current => current.ProductFiles)
                    .HasForeignKey(current => current.productId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public ProductFile()
        {

        }
        #endregion

        public string LocationFile { get; set; }

        #region ProductFile
        public virtual Product Product { get; set; }
        public int productId { get; set; }
        #endregion   



    }
}

