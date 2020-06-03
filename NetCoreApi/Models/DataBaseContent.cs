using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
    public class DataBaseContent : DbContext
    {
        public DataBaseContent(DbContextOptions<DataBaseContent> options)
         : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Userinfo> userinfo { get; set; }
        public DbSet<classlist> classlist { get; set; }
        public DbSet<Student> student { get; set; }
    }
}
