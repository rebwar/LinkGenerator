using LinkGenerator.Domain.Contracts.Links;
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
        private readonly ILinkGenerator _repository;

        public LinkController(ILinkGenerator repository)
        {
            _repository = repository;
        }



        [HttpGet("{code}")]
        public async Task<IActionResult> GetUrl(string code)
        {
            var result = await _repository.LinkRequset(code);
            if (result != null)
            {
                await _repository.AddVisits(result.LinkId);
                return Redirect(result.Url);
            }
            return NotFound();
        }

        [HttpGet("visits/{code}")]

        public async Task<IActionResult> GetVisitorCount(string code)
        {
            var result = await _repository.LinkRequset(code);
            if (result != null)
            {

                return Ok(result.Url + "  Visited:" + result.VisitCount + " Times!");
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> GenerateCode(LinkDto linkDto)
        {
            if (ModelState.IsValid)
            {
                Random rand = new Random();
                int stringlen = rand.Next(8, 20);
                int randValue;
                string str = "";
                char letter;
                for (int i = 0; i < stringlen; i++)
                {
                    randValue = rand.Next(0, 26);
                    letter = Convert.ToChar(randValue + 65);
                    str = str + letter;
                }
                var code = str;
                Link link = new Link
                {
                    Url = linkDto.Url,
                    VisitCount = 0,
                    GenerateCode = code
                };
                await _repository.CreateLink(link);
                return CreatedAtAction(nameof(GetUrl), new { code }, link);
            }
            else
            {
                return BadRequest();
            }
        }


    }

}
