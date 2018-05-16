using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal
{
    public class SzuroMemoDbContext: IdentityDbContext<User, IdentityRole<int>, int>
    {
        #region Constructor

        public SzuroMemoDbContext(DbContextOptions options): base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<LastScreening> LastScreening { get; set; }
        public DbSet<MedicalRecord> MedicalRecord { get; set; }
        public DbSet<Occasion> Occasion { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Screening> Screening { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LastScreening>().HasAlternateKey(ls => new { ls.MedicalRecordId, ls.ScreeningId });
            modelBuilder.Entity<Registration>().HasAlternateKey(r => new { r.OccasionId, r.UserId });
            modelBuilder.Entity<MedicalRecord>().HasAlternateKey(mr => new { mr.UserId });

            modelBuilder.Entity<Hospital>(e =>
            {
                e.OwnsOne(h => h.Address);
            });

            modelBuilder.Entity<MedicalRecord>(e =>
            {
                e.OwnsOne(m => m.Address);
            });

            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
