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
        
        /// <summary>
        /// Returns a list of all decisions in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Decision>>> GetAllDecisions()
        {
            var list = await Context.Decisions
                .Include(d=>d.ProsList)
                .Include(d=>d.ConsList)
                .ToListAsync();
            return list;
        }

        /// <summary>
        /// Returns a specific decision by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Decision>> GetDecisionById(int id)
        {
            var decision  = await Context.Decisions
                .Include(d => d.ProsList)
                .Include(d => d.ConsList)
                .SingleOrDefaultAsync(d=> d.DecisionId==id);
            return decision;
        }
        /// <summary>
        /// Add a new Decision to work on by specifying the decision idea
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Used to mark a decision ad 'Finished' and calculate the total value of pros and cons
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> TerminateDecision(int id)
        {
            var found = await Context.Decisions
                .Include(d=>d.ProsList)
                .Include(d=>d.ConsList)
                .SingleOrDefaultAsync(d=> d.DecisionId == id);
            if (found == null) return NotFound();
            found.Finished = true;
            found.ProsTotal = GetTotalValue(found.ProsList);
            found.ConsTotal = GetConsTotalValue(found.ConsList);

            Context.Entry(found).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(found);
        }

        private int GetTotalValue(List<Pro> list)
        {
            if (list == null) return 0;
            var total = 0;
            foreach (var reason in list)
            {
                total += reason.Importance;
            }
            return total;
        }
        private int GetConsTotalValue(List<Conn> list)
        {
            var total = 0;
            foreach (var reason in list)
            {
                total += reason.Importance;
            }
            return total;
        }
    }
}
