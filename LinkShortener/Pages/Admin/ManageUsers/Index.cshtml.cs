using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoverLandShop.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly LinkShortener.Data.LinkShortenerContext _context;

        public IndexModel(LinkShortener.Data.LinkShortenerContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
        }
    }
}
