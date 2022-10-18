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
    public class ConsController : ControllerBase
    {
        private readonly DecisionsDbContext Context;

        public ConsController(DecisionsDbContext context)
        {
            Context = context;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<List<Conn>>> GetAllReasonCons(int id)
        {
            var reason = await Context.Decisions
                .Include(d=>d.ConsList)
                .SingleOrDefaultAsync(d=>d.DecisionId==id);
            if (reason == null) return NotFound();
            var list = await Context.Cons
                .Where(c=> c.DecisionId == id)
                .ToListAsync();
            return list;
        }*/

        /// <summary>
        /// Add a Con to a decision by specifying the decision ID and the con details (name, importance)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Decision>> AddConToDecision(CreateReasonRequest request)
        {
            var decision = await Context.Decisions
                .Include(d => d.ProsList)
                .Include(d => d.ConsList)
                .SingleOrDefaultAsync(d => d.DecisionId == request.DecisionId);
            if (decision == null) return NotFound();
            if (request.ReasonName == null) return BadRequest();
            var newCon = new Conn
            {
                ReasonName = request.ReasonName,
                Importance = request.Importance,
                DecisionId = request.DecisionId,
                Decision = decision
            };
            await Context.Cons.AddAsync(newCon);
            await Context.SaveChangesAsync();
            return Ok(decision);
        }
    }
}
