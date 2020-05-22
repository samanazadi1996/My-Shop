using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Brand")]
    public class Brand : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Brand>
        {
            public Configuration()
            {
            }
        }
        #endregion /Configuration

        #region Constractor
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }
        #endregion

        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}

