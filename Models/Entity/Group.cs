using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Group")]
    public class Group : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Group>
        {
            public Configuration()
            {
            }
        }
        #endregion /Configuration

        #region Constractor
        public Group()
        {
            this.Products = new HashSet<Product>();

        }
        #endregion

        public string Name { get; set; }
        public Nullable<int> targetId { get; set; }

        public virtual ICollection<Product>  Products { get; set; }

    }
}

