﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookmakerAPI.Models;

namespace BookmakerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly BookmakerDBContext _context;

        public MatchesController(BookmakerDBContext context)
        {
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            var matches = _context.Matches;
            return await matches.ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return new JsonResult("Матч с таким ID не найден");
            }

            return match;
        }

        // PUT: api/Matches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, Match match)
        {
            if (id != match.MatchId)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult("Данные изменены");
        }

        // POST: api/Matches
        [HttpPost]
        public async Task<ActionResult<Match>> CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return new JsonResult("Матч добавлен");
        }

        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return new JsonResult("Матч удален");
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }
        [HttpGet]
        [Route("GetTeamName")]
        public JsonResult GetTeamName()
        {
            var result = from m in _context.Matches
                         join f in _context.Teams on m.FirstTeamId equals f.TeamId
                         join s in _context.Teams on m.SecondTeamId equals s.TeamId
                         select new
                         {
                             firstTeam = f.TeamName,
                             secondTeam = s.TeamName,
                             firstTeamId = f.TeamId,
                             secondTeamId = s.TeamId,
                             firstTeamScore = m.FirstTeamScore,
                             secondTeamScore = m.SecondTeamScore,
                             date = m.MatchDate,
                             matchId = m.MatchId
                         };

            return new JsonResult(result.ToList());
        }
    }
}
