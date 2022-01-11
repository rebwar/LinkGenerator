using LinkGenerator.Domain.Core.Links;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGenerator.Infrastructure.Data.DbConfiguration
{
    public class LinkDbContext:DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options):base(options)
        {

        }
        public DbSet<Link> Links { get; set; }
    }
}
