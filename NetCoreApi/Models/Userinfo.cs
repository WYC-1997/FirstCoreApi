using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
    public class Userinfo
    {
        [Key]
        public string Guid { get; set; } = new System.Guid().ToString();
        public string Name { get; set; }
        public string Pwd { get; set; }
        public string Sex { get; set; }
    }
}
