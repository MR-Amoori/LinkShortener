using System.Collections;
using System.Collections.Generic;

namespace LinkShortener.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ShortUrl> ShortUrls { get; set; }
        public IEnumerable<Script> Scripts { get; set; }
    }
}
