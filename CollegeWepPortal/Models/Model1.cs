namespace CollegeWepPortal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<STUDENT> STUDENTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<STUDENT>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.Role)
                .IsUnicode(false);
        }
    }
}
