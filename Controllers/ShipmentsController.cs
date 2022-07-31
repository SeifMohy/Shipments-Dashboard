using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipments.Models;

namespace Shipments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly ShipmentsContext _context;

        public ShipmentsController(ShipmentsContext context)
        {
            _context = context;
        }

        // GET: api/Shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            if (_context.Shipments == null)
            {
                return NotFound();
            }
            var shipments = new List<Shipment>();
            shipments.Add(new Shipment
            {
                Id = 1,
                OrderDate = "29/07/2022",
                Status = "Entered",
                Checked = false,
                ShipFrom = new Address
                {
                    AddressId = 1,
                    Company = "Company Name",
                    Contact = "Contact",
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country",
                },
                ShipTo = new Address
                {
                    AddressId = 2,
                    Company = "Company Name",
                    Contact = "Contact",
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country",
                },
                OrderLines = new List<OrderLine> {
            new OrderLine{
                OrderLineId  = 1,
                Description = "Product 1",
                Quantity = 3
            },
            new OrderLine{
                OrderLineId  = 2,
                Description = "Product 2",
                Quantity = 1
            },
        },
            });
            shipments.Add(new Shipment
            {
                Id = 2,
                OrderDate = "30/07/2022",
                Status = "Entered",
                Checked = false,
                ShipFrom = new Address
                {
                    AddressId = 3,
                    Company = "Company Name",
                    Contact = "Contact",
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country",
                },
                ShipTo = new Address
                {
                    AddressId = 4,
                    Company = "Company Name",
                    Contact = "Contact",
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country",
                },
                OrderLines = new List<OrderLine> {
            new OrderLine{
                OrderLineId  = 3,
                Description = "Product 3",
                Quantity = 3
            },
            new OrderLine{
                OrderLineId  = 4,
                Description = "Product 4",
                Quantity = 1
            },
        },
            });
            shipments.Add(new Shipment
            {
                Id = 3,
                OrderDate = "31/07/2022",
                Status = "Entered",
                Checked = false,
                ShipFrom = new Address
                {
                    AddressId = 1,
                    Company = "Company Name",
                    Contact = "Contact",
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country",
                },
                ShipTo = new Address
                {
                    AddressId = 4,
                    Company = "Company Name",
                    Contact = "Contact",
                    AddressLine1 = "AddressLine1",
                    AddressLine2 = "AddressLine2",
                    City = "City",
                    State = "State",
                    Zip = "Zip",
                    Country = "Country",
                },
                OrderLines = new List<OrderLine> {
            new OrderLine{
                OrderLineId  = 5,
                Description = "Product 5",
                Quantity = 2
            },
            new OrderLine{
                OrderLineId  = 6,
                Description = "Product 6",
                Quantity = 5
            },
        },
            });
            return shipments;
        }

        // GET: api/Shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            if (_context.Shipments == null)
            {
                return NotFound();
            }
            var shipment = await _context.Shipments.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

        // PUT: api/Shipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(int id, Shipment shipment)
        {
            if (id != shipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Shipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            if (_context.Shipments == null)
            {
                return Problem("Entity set 'ShipmentsContext.Shipments'  is null.");
            }
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipment", new { id = shipment.Id }, shipment);
        }

        // DELETE: api/Shipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            if (_context.Shipments == null)
            {
                return NotFound();
            }
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentExists(int id)
        {
            return (_context.Shipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
