using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWork.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
