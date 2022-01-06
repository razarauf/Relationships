using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Relationships.Models
{
    public class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        // many-to-many relationship 
        public ICollection<Grade> Grades { get; set; }
    }
}