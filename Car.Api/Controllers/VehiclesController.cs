using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car.Api.Data;
using Car.Api.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly DataContext _context;
        private decimal constValue = (decimal)200.000;

        public VehiclesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            return await _context.Vehicles.ToListAsync();
        }
        [HttpGet("{licensePlate}")]
        public async Task<ActionResult<Vehicle>> GetByLicensePlate(string licensePlate)
        {
            var model = await _context.Vehicles.FindAsync(licensePlate);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpPost]
        public async Task<ActionResult<Vehicle>> InsertVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            vehicle.Value = constValue;
            int day = vehicle.DateAdmission.Day;
            if ((day % 2) == 0)
            {
                vehicle.Value = vehicle.Value * (decimal)1.5;
            }
            if (vehicle.Model < 1997)
            {
                vehicle.Value = vehicle.Value * (decimal)1.20;
            }
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByLicensePlate), new { licensePlate = vehicle.LicensePlate }, vehicle);
        }
        [HttpPut]
        public async Task<IActionResult> EditVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Vehicle model = await _context.Vehicles.FindAsync(vehicle.LicensePlate);
            if (model == null)
            {
                return NotFound();            
            }
            model.Color = vehicle.Color;
            model.DateAdmission = vehicle.DateAdmission;
            model.Model = vehicle.Model;
            model.PhotoId = vehicle.PhotoId;
            model.Value = vehicle.Value;
            
            return Ok(model);
        }
        [HttpDelete("{licensePlate}")]
        public async Task<IActionResult> DeleteVehicle(string licensePlate)
        {
            if (string.IsNullOrEmpty(licensePlate))
            {
                return NotFound();
            }
            Vehicle model = await _context.Vehicles.FindAsync(licensePlate);
            if (model == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
}
