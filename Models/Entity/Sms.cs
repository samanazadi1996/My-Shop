using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Sms")]
    public class Sms : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Sms>
        {
            public Configuration()
            {
                HasRequired(current => current.User)
                    .WithMany(current => current.Sms)
                    .HasForeignKey(current => current.userId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public Sms()
        {

        }
        #endregion

        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }

        #region User
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion

    }
}

