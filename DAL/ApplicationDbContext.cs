using DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
