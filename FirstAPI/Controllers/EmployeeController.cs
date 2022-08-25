using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmoloyeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmoloyeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Employee e = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (e == null) return NotFound();

            return Ok(e);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, _context.Employees.ToList());
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return StatusCode(201);
        }

    }
}