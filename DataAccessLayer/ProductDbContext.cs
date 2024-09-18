using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public  class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }
      public DbSet<Products> Products { get; set; }
    }
}
