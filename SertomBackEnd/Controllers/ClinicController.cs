using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Data.Entities;
using Core.Services;
using Infrastructure.Data.Shared;

namespace SertomBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly MedyanaDbContext _context;
        private readonly ClinicService _clinic;

        public ClinicController(MedyanaDbContext context, ClinicService clinic)
        {
            _context = context;
            _clinic = clinic;
        }

        // GET: api/Clinic
        [HttpGet]
        public async Task<ActionResult<List<Clinic>>> Get()
        {
            var clinics = await _clinic.Get();
            if (clinics is null)
            {
                return NotFound();
            }
            return clinics;
        }

        // GET: api/Clinic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> Get(int id)
        {
            var clinic = await _clinic.Get(id);

            if (clinic == null)
            {
                return NotFound();
            }

            return clinic;
        }

        // PUT: api/Clinic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel>> Put(int id, Clinic clinic)
        {
            if (id != clinic.Id)
            {
                return BadRequest();
            }
            return await _clinic.Put(id, clinic);
        }

        // POST: api/Clinic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post(Clinic clinic)
        {
            return await _clinic.Post(clinic);
        }

        // DELETE: api/Clinic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _clinic.Delete(id);
        }

    }
}
