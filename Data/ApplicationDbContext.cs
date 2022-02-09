using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using umitHastanesiWeb.Models;

namespace umitHastanesiWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctor  { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<umitHastanesiWeb.Models.Language> Language { get; set; }
        public DbSet<umitHastanesiWeb.Models.Degree> Degree { get; set; }
    }
}
