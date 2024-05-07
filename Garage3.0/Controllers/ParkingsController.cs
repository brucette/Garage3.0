﻿using System;
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

        // POST: Parkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);
            if (parking != null)
            {
                _context.Parkings.Remove(parking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }
    }
}