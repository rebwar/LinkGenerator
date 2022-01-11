using LinkGenerator.Domain.Core.Links;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkGenerator.Domain.Contracts.Links
{
   public interface ILinkGenerator
    {
        Task CreateLink(string url);

        Task<Link> ShortLinkRequset(string code);

        

    }
}
