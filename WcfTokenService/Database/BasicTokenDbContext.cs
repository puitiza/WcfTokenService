namespace WcfTokenService.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BasicTokenDbContext : DbContext
    {
        public BasicTokenDbContext()
            : base("name=BasicTokenDbConnection")
        {
        }

        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Token)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
