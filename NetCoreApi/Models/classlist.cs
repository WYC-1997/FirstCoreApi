using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
    public class classlist
    {
        [Key]
        public string Guid { get; set; } = new System.Guid().ToString();
        public string ClassName { get; set; }
    }
}
