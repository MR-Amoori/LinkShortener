using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoverLandShop.Pages.Admin.ManageUsers
{
    public class DeleteModel : PageModel
    {
        private readonly LinkShortener.Data.LinkShortenerContext _context;

        public DeleteModel(LinkShortener.Data.LinkShortenerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.User.FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.User.FindAsync(id);

            if (Users != null)
            {
                _context.User.Remove(Users);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
