using AsigMent_c_5_MaiVanMinh_Pd09444;
using AsigMent_c_5_MaiVanMinh_Pd09444.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Data.Model
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }
        public DbSet<food> foods { get; set; }
        public DbSet<Combo> combos { get; set; }
        public DbSet<CustuMer> custumer { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         /* modelBuilder.Entity<Combo>().
              HasMany(e => e.foods)
              .WithOne(e => e.Combo)
              .HasForeignKey(e => e.comboid);*/
            /* modelBuilder.Entity<employee>().
                 HasOne(e => e.department).WithMany(e => e.employee)
              .HasForeignKey<department>(e => e.EmployeeId);*/
        }
    }
}
