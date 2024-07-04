using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TodoApi.Models;
namespace TodoApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("buy")]
        public async Task<IActionResult> BuyCurrency(int userId, string currency, double amount, double leverage)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            double rate = currency == "A" ? Market.GetCurrencyARate() : Market.GetCurrencyBRate();
            double totalCost = amount * leverage * rate;

            if (currency == "A" && user.CurrencyA >= totalCost)
            {
                user.CurrencyA -= totalCost;
            }
            else if (currency == "B" && user.CurrencyB >= totalCost)
            {
                user.CurrencyB -= totalCost;
            }
            else
            {
                return BadRequest("Insufficient funds.");
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}