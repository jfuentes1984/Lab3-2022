using Lab3_2022.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab3_2022.Pages_User
{
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
        public async Task<IActionResult> OnGetAsync()
        {
            UserInfo = await _context.User.FirstOrDefaultAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (UserInfo != null)
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                _context.Attach(UserInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }


            _logger.Log(LogLevel.Information, UserInfo.Name);
            return RedirectToPage("../Index");
        }
    }
}
