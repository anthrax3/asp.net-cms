using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReportsCMS.Models;

namespace ReportsCMS.DAL
{
    public class CategoriesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CategoryContext>
    {
        protected override void Seed(CategoryContext context)
        {
            var categories = new List<Category>
            {
                new Category{Id = Guid.Parse("5a6a6a78-946b-450f-bf00-0c9460c33ac7"), Name ="Sales"},
                new Category{Id = Guid.Parse("b1923a06-217e-42a8-b4ea-700bac65b7e8"),Name="Orders"},
                new Category{Id = Guid.Parse("6b91770e-be5a-4da3-aa39-9000cec65fae"),Name="Inventory"},
                new Category{Id = Guid.Parse("ca8a377f-42ed-4fb2-923c-1d1cd197db82e"),Name="Reconciliation"},
                new Category{Id = Guid.Parse("212c6279-6520-48fe-b9a3-8217776c2fe7"),Name="Audit"},
                new Category{Id = Guid.Parse("6768d1dc-6af2-43b4-9ab9-19f8d67dca6e"),Name="Outlet"},
            };

            var reportLinks = new List<ReportLinks>
            {
                new ReportLinks {Id = Guid.NewGuid(),Display = true,ParentCategoryId =Guid.Parse("5a6a6a78-946b-450f-bf00-0c9460c33ac7"),Link = "www.www.com",ReportName = "Sales By Country"},
                new ReportLinks {Id = Guid.NewGuid(),Display = true,ParentCategoryId =Guid.Parse("5a6a6a78-946b-450f-bf00-0c9460c33ac7"),Link = "www.www.com",ReportName = "Sales By Region"},
                new ReportLinks {Id = Guid.NewGuid(),Display = true,ParentCategoryId =Guid.Parse("5a6a6a78-946b-450f-bf00-0c9460c33ac7"),Link = "www.www.com",ReportName = "Sales By Farmer"},
                new ReportLinks {Id = Guid.NewGuid(),Display = true,ParentCategoryId =Guid.Parse("b1923a06-217e-42a8-b4ea-700bac65b7e8"),Link = "www.www.com",ReportName = "Orders By Country"},
                new ReportLinks {Id = Guid.NewGuid(),Display = true,ParentCategoryId =Guid.Parse("6b91770e-be5a-4da3-aa39-9000cec65fae"),Link = "www.www.com",ReportName = "Inventory By Country"}
            };

            categories.ForEach(c => context.Categories.Add(c));
            reportLinks.ForEach(r => context.ReportLinkses.Add(r));
            context.SaveChanges();
        }
    }
}