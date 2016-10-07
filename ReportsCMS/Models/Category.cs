using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportsCMS.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ReportLinks
    {
        public string ReportName { get; set; }
        public Guid Id { get; set; }
        public Guid ParentCategoryId { get; set; }
        public string Link { get; set; }
        public bool Display { get; set; }
    }
}