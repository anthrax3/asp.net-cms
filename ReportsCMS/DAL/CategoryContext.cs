using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using ReportsCMS.Controllers;
using ReportsCMS.Models;

namespace ReportsCMS.DAL
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(): base("CategoryContext")
        {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<ReportLinks> ReportLinkses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}