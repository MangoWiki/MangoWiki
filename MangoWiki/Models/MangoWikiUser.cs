using Microsoft.AspNetCore.Identity;

namespace MangoWiki.Models
{
    public class MangoWikiUser : IdentityUser
    {
        public bool CanNotify { get; set; }
    }
}
