using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class empmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public string Company { get; set; }
    }
}