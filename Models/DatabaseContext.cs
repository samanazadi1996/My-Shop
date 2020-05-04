using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Models
{
    public class DatabaseContext:DbContext
    {

        static DatabaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }

        public DatabaseContext() : base()
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Sms> sms { get; set; }
        public DbSet<ProductFile> productFiles { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Value> values { get; set; }

        public virtual int rebuildIndex()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rebuildIndex");
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new User.Configuration());
            modelBuilder.Configurations.Add(new Product.Configuration());
            modelBuilder.Configurations.Add(new Comment.Configuration());
            modelBuilder.Configurations.Add(new Group.Configuration());
            modelBuilder.Configurations.Add(new Order.Configuration());
            modelBuilder.Configurations.Add(new Ticket.Configuration());
            modelBuilder.Configurations.Add(new Value.Configuration());
            modelBuilder.Configurations.Add(new ProductFile.Configuration());
            modelBuilder.Configurations.Add(new Sms.Configuration());
        }
    }
}
