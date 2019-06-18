using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewCustomerCheck.Models
{
    public class NewCustomerCheckContext : DbContext
    {
        public NewCustomerCheckContext (DbContextOptions<NewCustomerCheckContext> options)
            : base(options)
        {
        }

        public DbSet<NewCustomerCheck.Models.ActivityModel> ActivityModel { get; set; }
    }
}
