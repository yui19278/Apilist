using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace Todolist.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetRanking()
        {
            var users = await _context.Users
                .Select(u => new { u.Name, TotalAssets = u.CurrencyA + u.CurrencyB })
                .OrderByDescending(u => u.TotalAssets)
                .ToListAsync();

            return Ok(users);
        }
    }
}