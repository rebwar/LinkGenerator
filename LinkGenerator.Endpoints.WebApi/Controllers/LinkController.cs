using LinkGenerator.Domain.Core.Links;
using LinkGenerator.Endpoints.WebApi.Models;
using LinkGenerator.Infrastructure.Data.Links;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkGenerator.Endpoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly LinkRepository _repository;

        public LinkController(LinkRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUrl(string code)
        {
            var result = await _repository.LinkRequset(code);
            if (result != null)
            {
                await _repository.AddVisits(result.LinkId);
                Redirect(result.Url);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateCode(LinkDto linkDto)
        {
            if (ModelState.IsValid) {
                Link link = new Link
                {
                    Url = linkDto.Url,
                    VisitCount = 0,
                    GenerateCode = GenerateRandomText()
                };
               await _repository.CreateLink(link);


            }
            else
            {
                return BadRequest();
            }
        }

        public string GenerateRandomText()
        {
            Random rand = new Random();
            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            return str;
        }
    }
   
}
