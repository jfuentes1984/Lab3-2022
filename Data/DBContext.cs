#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab3_2022.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DBContext : IdentityDbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<SiteUser> SiteUser { get; set; }
}
