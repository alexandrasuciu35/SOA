using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentGroup { get; set; }
        public string Address { get; set; }
        public string Departament { get; set; }

    }
}