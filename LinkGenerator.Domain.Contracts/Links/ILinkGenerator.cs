using LinkGenerator.Domain.Core.Links;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkGenerator.Domain.Contracts.Links
{
   public interface ILinkGenerator
    {
        Task CreateLink(Link link);

        Task<Link> LinkRequset(string code);

        Task<bool> CheckUniqueCode(string code);

        Task AddVisits(int id);

        

    }
}
