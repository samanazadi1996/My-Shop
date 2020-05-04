using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Ticket")]
    public class Ticket : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Ticket>
        {
            public Configuration()
            {
                HasRequired(current => current.User)
                    .WithMany(current => current.Tickets)
                    .HasForeignKey(current => current.userId)
                    .WillCascadeOnDelete(false);
            }
        }
        #endregion /Configuration

        #region Constractor
        public Ticket()
        {

        }
        #endregion

        public string Description { get; set; }
        public DateTime Datetime { get; set; }

        #region UserSender
        public virtual User User { get; set; }
        public int userId { get; set; }
        #endregion   



    }
}

