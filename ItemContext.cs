using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruYum_WebAPI
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }

        public DbSet<ClsUser> Users { get; set; }
        public DbSet<ClsMenuItem> MenuItems { get; set; }
    }
}
