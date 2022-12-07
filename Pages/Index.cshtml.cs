using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages;

public class IndexModel : PageModel
{
    private readonly FinalProject.Models.Context _context;

    public IndexModel(FinalProject.Models.Context context)
    {
        _context = context;
    }

    public IList<Firearm> Firearm { get;set; } = default!;

    public async Task OnGetAsync()
        {
            if (_context.Firearm != null)
            {
                Firearm = await _context.Firearm.Include(s => s.Orders!).ThenInclude(sc => sc.Customer).ToListAsync();
            }
        }
}

