using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoverLandShop.Pages.Admin.ManageUsers
{
    public class EditModel : PageModel
    {
        private readonly LinkShortener.Data.LinkShortenerContext _context;

        public EditModel(LinkShortener.Data.LinkShortenerContext context)
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

            Users = await _context.User.Include(u => u.ShortUrls).FirstOrDefaultAsync(m => m.UserId == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(Users.UserId))
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

        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
