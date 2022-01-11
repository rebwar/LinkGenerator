using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkGenerator.Endpoints.WebApi.Models
{
    public class LinkDto
    {
        [Required]
        [Url]
        public string Url { get; set; }

       
    }
}
