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
using static System.Net.Mime.MediaTypeNames;
using Microsoft.CodeAnalysis.CSharp;

namespace Garage3._0.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage3_0Context _context;

        public MembersController(Garage3_0Context context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var members = _context.Members.Select(m => new MemberIndexViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Membership = m.Membership,
                NumberOfVehicles = m.Ownerships.Count
            }).OrderBy(m => m.FirstName.Substring(0, 2));

            //order the member list according to firstname and its 2 letters at beginning
            //var members = await _context.Members.OrderBy(m => m.FirstName.Substring(0,2)).ToListAsync();

            return View(await members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
            .Include(p => p.Ownerships)
            .FirstOrDefaultAsync(m => m.Id == id);


            if (member == null)
            {
                return NotFound();
            }

            int numberOfVehicles = 0;
            if (member.Ownerships != null)
            {
                numberOfVehicles = member.Ownerships.Count;
            }

            var viewModel = new MemberDetailsViewModel()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Membership = member.Membership,
                Ownerships = member.Ownerships,
                NumberOfVehicles = numberOfVehicles
            };

            return View(viewModel);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Membership")] Member member)
        {
            if (ModelState.IsValid)
            {
                // Check if the personal number already exists, i.e this means the member are alredy is registered
                var existingPersonNumber= await _context.Members.FirstOrDefaultAsync(v => v.Id == member.Id);
                if (existingPersonNumber != null)
                {
                    ModelState.AddModelError(nameof(member.Id), "This social security number is already registered.");
                    return View(member);
                }
                try
                {
                    IActionResult idValidityResult = CheckIdValidity(member.Id);
                    if (idValidityResult is BadRequestObjectResult)
                    {
                        //return idValidityResult;
                        SetFeedback("danger", "Sorry, you must be at least 18 years old to be member!");
                        return View();
                    }

                    _context.Add(member);
                    await _context.SaveChangesAsync();
                    SetFeedback("success", "Member was successfully registered!");
                    return View();
                }
                catch (FormatException)
                {
                    SetFeedback("danger", "The social security number was not in a correct format");
                    return View();
                }
                catch (DbUpdateException)
                {
                    SetFeedback("danger", "A member with that social security number already exists");
                    return View();
                }
            }
            else if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Membership")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //check that the member doesn't have a vehicle in parking or connected vehicle before removing the member?
            var memberHasParkedVehicles = await _context.Parkings.AnyAsync(p => p.Ownership.MemberId == id);

            //check if the member has any connected vehicles
            var memberHasConnectedVehicles = await _context.Vehicle.AnyAsync(v => v.Id == id);

            if ( memberHasConnectedVehicles || memberHasParkedVehicles)
            {
                TempData["DeleteMemberError"] = "This member cannot be deleted because they have parked vehicle or connected vehicles in database";
                return RedirectToAction(nameof(Delete));
            }

            // If the member doesn't have parked or connected vehicles, proceed with deletion
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(string id)
        {
            return _context.Members.Any(e => e.Id == id);
        }


        // AGE VERIFICATION: members are only 18 years or older 
        public IActionResult CheckIdValidity(string Id)
        {

            string firstpart = Id.Substring(0, 8);
            DateTime dateOfBirth;
            dateOfBirth = DateTime.ParseExact(firstpart, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - dateOfBirth.Year;

            if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
            {
                age--;
            }

            if (age < 18)
                return BadRequest("Bad request");
            else
                return Ok(new { DateOfBirth = dateOfBirth });
        }

        private void SetFeedback(string messageType, string message)
        {
            ViewBag.Message = message;
            ViewBag.MessageType = messageType;
        }
    }
}
