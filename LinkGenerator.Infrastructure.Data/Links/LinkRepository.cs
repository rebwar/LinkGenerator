using LinkGenerator.Domain.Contracts.Links;
using LinkGenerator.Domain.Core.Links;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkGenerator.Infrastructure.Data.Links
{
    public class LinkRepository : ILinkGenerator
    {
        public Task CreateLink(string url)
        {
            throw new NotImplementedException();
        }

        public Task<Link> ShortLinkRequset(string code)
        {
            throw new NotImplementedException();
        }
    }
}
