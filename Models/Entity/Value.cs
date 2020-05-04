using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    [Table("Value")]
    public class Value : BaseEntity
    {
        #region Configuration
        internal class Configuration : EntityTypeConfiguration<Value>
        {
            public Configuration()
            {
            }
        }
        #endregion /Configuration

        #region Constractor
        public Value()
        {

        }
        #endregion

        public string Name { get; set; }
        public string Text { get; set; }
        public string Content { get; set; }
        public string type { get; set; }
        public DateTime DateTime { get; set; }

    }
}

