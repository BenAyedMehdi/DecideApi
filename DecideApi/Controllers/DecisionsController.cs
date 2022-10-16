using DecideApi.Data;
using DecideApi.Models;
using DecideApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecideApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecisionsController : ControllerBase
    {
        private readonly DecisionsDbContext Context;

        public DecisionsController(DecisionsDbContext context)
        {
            Context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Decision>>> GetAllDecisions()
        {
            var list = await Context.Decisions.ToListAsync();
            return list;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Decision>> AddDecision(CreateDecisionRequest request)
        {
            if (request.Idea == null || request.Idea == string.Empty) return BadRequest();
            var newDecision = new Decision
            {
                Idea = request.Idea,
            };
            await Context.Decisions.AddAsync(newDecision);
            await Context.SaveChangesAsync();
            return Ok(newDecision);
        }

    }
}
