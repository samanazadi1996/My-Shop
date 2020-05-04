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

        public string Province { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }

        #region User
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion   

    }
}