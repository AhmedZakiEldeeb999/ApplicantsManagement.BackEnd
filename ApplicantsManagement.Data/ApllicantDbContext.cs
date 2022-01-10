using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using ApplicantsManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicantsManagement.Data
{
    public class ApllicantDbContext: DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public ApllicantDbContext()
        {

        }
        public ApllicantDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
