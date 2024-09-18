using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstTask.Models
{
    public class ApplacationDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<studentDetails> StudentDetails { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
                .HasOptional(sd => sd.StudentDetails)
                .WithRequired(s => s.Students);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithRequired(c => c.teacher)
                .HasForeignKey(c => c.TeacherID);

            base.OnModelCreating(modelBuilder);
        }
    }
}