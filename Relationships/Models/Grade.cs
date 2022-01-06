using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Relationships.Models
{
    public class Grade
    {

        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        // many-to-many relationship 
        public ICollection<Student> Students { get; set; }
    }
}