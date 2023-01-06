using LinkShortener.Data;
using LinkShortener.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkShortener.Pages.Admin.ManageScripts
{
    public class IndexModel : PageModel
    {
        private LinkShortenerContext _context;

        public IndexModel(LinkShortenerContext context)
        {
            _context = context;
        }
        public List<Script> Scripts { get; set; }
        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Scripts = await _context.Scripts.Include(c=>c.User).ToListAsync();
            Users = await _context.User.ToListAsync();
        }
    }
}
