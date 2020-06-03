using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
    public class Student
    {
        [Key]
        public string Guid { get; set; } = new System.Guid().ToString();
        public string StuName { get; set; }
        public int ClassID { get; set; }
        public int StuFraction { get; set; }
        public int StuState { get; set; }
    }
}
