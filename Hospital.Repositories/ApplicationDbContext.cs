using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<HospitalInfo> HospitalInfo { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<LabReport> LabReports { get; set; }
        public DbSet<LabReportCategory> LabReportCategory { get; set; }
        public DbSet<Medecine> Medecines { get; set; }

        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Department> Department { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<MedecineInfo>()
            //    .HasOne(b => b.Prescription)
            //    .WithMany(a => a.MedecineNames)
            //    .HasForeignKey(b => b.Id);

            //base.OnModelCreating(modelBuilder);
        }

    }

}
