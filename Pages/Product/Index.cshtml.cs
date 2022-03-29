#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3_2022.Model;
using System.Security.Claims;

namespace Lab3_2022.Pages_Product;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DBContext _context;
    [BindProperty]
    public User? UserInfo { get; set; }

    public IndexModel(ILogger<IndexModel> logger, DBContext context)
    {
        _logger = logger;
        _context = context;
    }
    public string? UserEmail { get; set; }

    public IList<Lab3_2022.Model.Product> Product { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Product = await _context.Product.ToListAsync();
        if (User.Identity != null)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            if (claimsIdentity.IsAuthenticated)
            {
                var email = claimsIdentity.FindFirst(ClaimTypes.Email);
                if (email != null)
                {
                    UserEmail = email.Value;
                    _logger.Log(LogLevel.Information, email.Value);
                }
            }
        }

        return Page();
    }
}


