using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGenerator.Domain.Core.Links
{
   public class Link
    {
        public int LinkId { get; set; }
        public string Url { get; set; }
        public string GenerateCode { get; set; }
        public long VisitCount { get; set; }
    }
}
