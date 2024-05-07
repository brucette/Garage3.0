using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Data;
using Garage3._0.Entites;
using Garage3._0.ModelView;

namespace Garage3._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage3_0Context _context;

        public VehiclesController(Garage3_0Context context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicle
                .Include(v => v.Ownerships)
                    .ThenInclude(o => o.Member)
                .Include(v => v.VehicleType) // Include VehicleType information
                .ToListAsync();

            return View(vehicles);
        }


        // GET: VehicleTypes
        public async Task<IActionResult> IndexVehicleTypes()
        {
            var vehicleTypes = await _context.VehicleTypes
                .Include(vt => vt.VehicleTypeId)
                .ToListAsync();

            return View(vehicleTypes);
        }


        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddVehicleModelView viewModel)
        {
            if (ModelState.IsValid)
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == viewModel.OwnerPersonalNumber);
                if (member != null)
                {
                    var vehicle = new Vehicle
                    {
                        Id = viewModel.RegisterNumber.ToUpper().Trim(),
                        Color = viewModel.Color,
                        Brand = viewModel.Brand,
                        ModelType = viewModel.ModelType,
                        VehicleTypeId = viewModel.VehicleTypeId
                    };
                    _context.Add(vehicle);

                    var ownership = new Ownership
                    {
                        MemberId = viewModel.OwnerPersonalNumber,
                        VehicleId = viewModel.RegisterNumber,
                    };
                    _context.Add(ownership);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(nameof(viewModel.OwnerPersonalNumber), "Owner not found.");
                }
            }
            // Lägg till valideringsmeddelanden om modellen inte är giltig eller om medlemmen inte finns.
            else
            {
                if (string.IsNullOrEmpty(viewModel.RegisterNumber) || viewModel.RegisterNumber.Length != 6)
                {
                    ModelState.AddModelError(nameof(viewModel.RegisterNumber), "Register Number must be 6 characters long.");
                }
            }

            return View(viewModel);
        }

        //// GET: Summary
        //public async Task<IActionResult> Summary()
        //{
        //    var vehicles = _context.Vehicle.Select(vehicle => new Parking
        //    {
        //        VehicleId = Parking.VehicleId,
        //        RegistrationNumber = vehicle.RegistrationNumber,
        //        ArrivalTime = vehicle.ArrivalTime,
        //        TotParkingTime = DateTime.Now - vehicle.ArrivalTime
        //    });

        //    return View(await vehicles.ToListAsync());
        //}


        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Color,ModelType,Brand")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(string id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
