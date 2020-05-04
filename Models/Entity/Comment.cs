using Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Comment")]
    public class Comment : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Comment>
        {
            public Configuration()
            {
                HasRequired(current => current.User)
                    .WithMany(current => current.Comments)
                    .HasForeignKey(current => current.userId)
                    .WillCascadeOnDelete(false);

                HasRequired(current => current.Product)
                    .WithMany(current => current.Comments)
                    .HasForeignKey(current => current.productId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public Comment()
        {

        }
        #endregion

        public string Text { get; set; }
        public DateTime Datetime { get; set; }
        public Nullable<RateType> rate { get; set; }


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

