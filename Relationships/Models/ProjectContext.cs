using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Relationships.Models
{
    public class ProjectContext : DbContext 
    {

        public ProjectContext()
            : base ("name=DefaultConnection")
        { 
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}