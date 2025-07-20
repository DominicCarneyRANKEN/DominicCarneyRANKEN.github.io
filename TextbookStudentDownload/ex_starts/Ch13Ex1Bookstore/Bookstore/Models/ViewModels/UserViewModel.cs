using Microsoft.AspNetCore.Identity;
using Bookstore.Models.DomainModels;

namespace Bookstore.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
