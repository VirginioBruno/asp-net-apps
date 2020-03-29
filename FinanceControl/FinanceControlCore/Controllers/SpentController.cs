using System;
using System.Collections.Generic;
using FinanceControl.Infrastructure;
using FinanceControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpentController : Controller
    {  

        private readonly FinanceControlContext _context;
        public SpentController(FinanceControlContext context) => this._context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Spent>> Get() 
        {
            return Ok(_context.SpentItems);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Spent>> Get(int id) 
        {
            var spent = _context.SpentItems.Find(id);

            if(spent == null)
                return NotFound();

            return Ok(spent);
        }

        [HttpPost]
        public ActionResult<Spent> Post(Spent spent) 
        {
            _context.SpentItems.Add(spent);
            _context.SaveChanges();

            return spent;
        }

        [HttpPut("{id}")]
        public ActionResult<Spent> Put(int id, Spent spent) 
        {
            if(id != spent.Id)
                return BadRequest();
            
            _context.Entry(spent).State = EntityState.Modified;
            _context.SaveChanges();

            return _context.SpentItems.Find(spent.Id);
        }
    }
}
