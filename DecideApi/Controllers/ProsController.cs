using DecideApi.Data;
using DecideApi.Models.DTO;
using DecideApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecideApi.Controllers
{
    [Route("api/Decision/[controller]")]
    [ApiController]
    public class ProsController : ControllerBase
    {
        private readonly DecisionsDbContext Context;

        public ProsController(DecisionsDbContext context)
        {
            Context = context;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<List<Pro>>> GetAllDecisionPros(int id)
        {
            var decision = await Context.Decisions
                .Include(d => d.ProsList)
                .SingleOrDefaultAsync(d => d.DecisionId == id);
            if (decision == null) return NotFound();
            var list = await Context.Pros
                .Where(p => p.DecisionId == id)
                .ToListAsync();
            return list;
        }
        */

        /// <summary>
        /// Add a Pro to a decision by specifying the decision ID and the pro details (name, importance)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Decision>> AddProToDecision(CreateReasonRequest request)
        {
            var decision = await Context.Decisions
                .Include(d=>d.ProsList)
                .Include(d=>d.ConsList)
                .SingleOrDefaultAsync(d=>d.DecisionId == request.DecisionId);
            if (decision == null) return NotFound();
            if (request.ReasonName == null) return BadRequest();
            var newPro = new Pro
            {
                ReasonName = request.ReasonName,
                Importance = request.Importance,
                DecisionId = request.DecisionId,
                Decision = decision
            };
            await Context.Pros.AddAsync(newPro);
            await Context.SaveChangesAsync();
            return Ok(decision);
        }
    }
}
