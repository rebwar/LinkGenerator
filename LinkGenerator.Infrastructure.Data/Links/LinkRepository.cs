using LinkGenerator.Domain.Contracts.Links;
using LinkGenerator.Domain.Core.Links;
using LinkGenerator.Infrastructure.Data.DbConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkGenerator.Infrastructure.Data.Links
{
    public class LinkRepository : ILinkGenerator
    {
        private readonly LinkDbContext _context;

        public LinkRepository(LinkDbContext context)
        {
            _context = context;
        }

        public async Task CreateLink(Link link)
        {
            await _context.Links.AddAsync(link);
            await _context.SaveChangesAsync();
        }

        public async Task<Link> LinkRequset(string code)
        {
            var link = await _context.Links.SingleOrDefaultAsync(c => c.GenerateCode == code);
            return link;
        }

        public async Task AddVisits(int id)
        {
            var result = await _context.Links.SingleOrDefaultAsync(t => t.LinkId == id);
            result.VisitCount += 1;
            _context.SaveChanges();
        }


    }
}
