using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Data;
using Garage3._0.Entites;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Garage3._0.ModelView;

namespace Garage3._0.Controllers
{
    public class ParkingsController : Controller
    {
        private readonly Garage3_0Context _context;

        public ParkingsController(Garage3_0Context context)
        {
            _context = context;
        }

        // GET: Parkings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parkings.ToListAsync());
        }

        public async Task<IActionResult> SearchParkedVehiclesByRegNumber(string regNumber)
        {
            var query = _context.Parkings
                    .Include(p => p.Ownership)
                        .ThenInclude(m => m.Member)
                    .Include(p => p.Ownership)
                        .ThenInclude(v => v.Vehicle)
                    .AsQueryable(); // Start with a base query

            if (string.IsNullOrWhiteSpace(regNumber))
            {
                // If regNumber field is empty, retrieve all vehicles
                query = query.Where(p => true); 
            }
            else
            {
                // Otherwise, filter by regNumber
                query = query.Where(p => p.VehicleId == regNumber.ToUpper().Trim());
            }

            var model = await query.ToListAsync();

            if (!model.Any())
            {
                TempData["NoVehicleFound"] = "No vehicles found with the specified registration number.";
            }
            else if(model.Any() && !string.IsNullOrWhiteSpace(regNumber)) 
            {
                TempData["VehicleFound"] = $"Vehicle with Licence Plate {model.First().VehicleId.ToUpper()} were found.";
                //TempData["VehicleId"] = model.First().VehicleId; // Set the vehicle ID
            }

            var viewModelList = model.Select(p => new GarageViewModel
            {
                OwnerName = p.Ownership.Member.FullName,
                PersonalNumber = p.Ownership.Member.Id,
                Membership = p.Ownership.Member.Membership,
                ParkingLot = p.ParkingLotNumber,
                ArrivalTime = p.ArrivalTime,
                RegistrationNumber = p.Ownership.Vehicle.Id,
                Color = p.Ownership.Vehicle.Color,
                ModelType = p.Ownership.Vehicle.ModelType,
                Brand = p.Ownership.Vehicle.Brand
            }).ToList();

            return View("ParkedVehicles", viewModelList);
        }


        public async Task<IActionResult> ParkedVehicles()
        {
            var parkedData = await _context.Parkings
                .Include(p => p.Ownership)
                    .ThenInclude(m => m.Member)
                .Include(p => p.Ownership)
                    .ThenInclude(v => v.Vehicle)
                .ToListAsync();

            if (parkedData == null)
            {
                return NotFound();
            }

            var viewModelList = new List<GarageViewModel>(); // List to hold view models

            foreach (var parkedVehicle in parkedData)
            {

                var viewModel = new GarageViewModel
                {
                    OwnerName = parkedVehicle.Ownership.Member.FullName,
                    PersonalNumber = parkedVehicle.Ownership.Member.Id,
                    Membership = parkedVehicle.Ownership.Member.Membership,
                    ParkingLot = parkedVehicle.ParkingLotNumber,
                    ArrivalTime = parkedVehicle.ArrivalTime,
                    RegistrationNumber = parkedVehicle.Ownership.Vehicle.Id,
                    Color = parkedVehicle.Ownership.Vehicle.Color,
                    ModelType = parkedVehicle.Ownership.Vehicle.ModelType,
                    Brand = parkedVehicle.Ownership.Vehicle.Brand,
                    //NumWheels = parkedData.Ownership.Vehicle.VehicleType.NumWheels
                    //Type = parkedData.Ownership.Vehicle.VehicleType.Type

                };

                viewModelList.Add(viewModel);
            }


            return View(viewModelList);
        }

        // GET: Parkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // GET: Parkings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParkingLotNumber,ArrivalTime,VehicleId")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                    // Find the ownership by vehicle registration number
                    var ownership = await _context.Ownerships
                        .FirstOrDefaultAsync(o => o.VehicleId == parking.VehicleId);

                    if (ownership == null)
                    {
                        // If ownership is not found, return error or handle accordingly
                        ModelState.AddModelError("VehicleId", "Ownership not found");
                        return View(parking);
                    }

                    // Assign the ownership to the parking
                    parking.Ownership = ownership;

                    // Add the parking to the context and save changes
                    _context.Parkings.Add(parking);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }


            // If ModelState is not valid, return to the view
            return View(parking);
        }



        // GET: Parkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }
            return View(parking);
        }

        // POST: Parkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParkingLotNumber,ArrivalTime,VehicleId")] Parking parking)
        {
            if (id != parking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingExists(parking.Id))
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
            return View(parking);
        }

        // GET: Parkings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var parking = await _context.Parkings
                .Include(p => p.Ownership)
                .FirstOrDefaultAsync(m => m.Id == id);*/

            var parking = await _context.Parkings
               .Include(p => p.Ownership)
                   .ThenInclude(m => m.Member)
               .Include(p => p.Ownership)
                   .ThenInclude(v => v.Vehicle)
               .FirstOrDefaultAsync();

            if (parking != null)
            {

                // Calculate receipt details
                var checkOutTime = DateTime.Now;
                var ParkingPrice = 1; // Assuming price is 1kr per minute
                var totalParkingTime = (checkOutTime - parking.ArrivalTime);
                var convertedTotParkingTime = Math.Round((double)totalParkingTime.TotalMinutes, 2);
                var price = Math.Round(convertedTotParkingTime * ParkingPrice, 2);

                var viewModel = new ReceiptViewModel
                {
                    PersonNumber = parking.Ownership.MemberId,
                    RegistrationNumber = parking.VehicleId,
                    VehicleType = parking.Ownership.Vehicle.VehicleTypeId,
                    Color = parking.Ownership.Vehicle.Color,
                    Model = parking.Ownership.Vehicle.ModelType,
                    Brand = parking.Ownership.Vehicle.Brand,
                    CheckInTime = parking.ArrivalTime,
                    CheckOutTime = checkOutTime,
                    TotalParkingTimeInMinutes = totalParkingTime,
                    Price = price

                };

                // Create receipt entity
                var receipt = new Receipt
                {
                    ArrivalTime = parking.ArrivalTime,
                    CheckOut = checkOutTime,
                    TotParkingTime = totalParkingTime,
                    Price = price,
                    VehicleId = parking.VehicleId,
                    Ownership = parking.Ownership // Assign the ownership
                };

                // Add receipt to context
                _context.Receipts.Add(receipt);

                // Remove parked vehicle
                _context.Parkings.Remove(parking);

                // Save changes
                await _context.SaveChangesAsync();

                // Pass viewModel to the view
                return View("ViewReceipt", viewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }

    }
}
