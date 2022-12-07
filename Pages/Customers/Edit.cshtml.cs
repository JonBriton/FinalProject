using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly FinalProject.Models.Context _context;

        public EditModel(FinalProject.Models.Context context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public List<Firearm> Firearms {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer =  await _context.Customer.Include(s => s.Orders!).ThenInclude(sc => sc.Firearm).FirstOrDefaultAsync(m => m.CustomerID == id);
            Firearms = _context.Firearm.ToList();
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedFirearms)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerToUpdate = await _context.Customer.Include(s => s.Orders!).ThenInclude(sc => sc.Firearm).FirstOrDefaultAsync(m => m.CustomerID == Customer.CustomerID);
            if (customerToUpdate != null) 
            {
                customerToUpdate.FirstName = Customer.FirstName;
                customerToUpdate.LastName = Customer.LastName;
                
                // Separate method to update the courses because it can get complex
                UpdateOrders(selectedFirearms, customerToUpdate);
            }

            //_context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
          return _context.Customer.Any(e => e.CustomerID == id);
        }

        private void UpdateOrders(int[] selectedFirearms, Customer customerToUpdate)
        {
            if (selectedFirearms == null)
            {
                customerToUpdate.Orders = new List<Order>();
                return;
            }

            List<int> currentFirearms = customerToUpdate.Orders!.Select(c => c.FirearmID).ToList();
            List<int> selectedFirearmsList = selectedFirearms.ToList();

            foreach (var firearm in _context.Firearm)
            {
                if (selectedFirearmsList.Contains(firearm.FirearmID))
                {
                    if (!currentFirearms.Contains(firearm.FirearmID))
                    {
                        // Add course here
                        customerToUpdate.Orders!.Add(
                            new Order { CustomerID = customerToUpdate.CustomerID, FirearmID = firearm.FirearmID }
                        );
                        _logger.LogWarning($"Customer {customerToUpdate.FirstName} {customerToUpdate.LastName} ({customerToUpdate.CustomerID}) - ADD {firearm.FirearmID} {firearm.Model}");
                    }
                }
                else
                {
                    if (currentFirearms.Contains(firearm.FirearmID))
                    {
                        // Remove course here
                        Order firearmToRemove = customerToUpdate.Orders!.SingleOrDefault(s => s.FirearmID == firearm.FirearmID)!;
                        _context.Remove(firearmToRemove);
                        _logger.LogWarning($"Student {customerToUpdate.FirstName} {customerToUpdate.LastName} ({customerToUpdate.CustomerID}) - DROP {firearm.FirearmID} {firearm.Model}");
                    }
                }
            }
        }
    }
}
