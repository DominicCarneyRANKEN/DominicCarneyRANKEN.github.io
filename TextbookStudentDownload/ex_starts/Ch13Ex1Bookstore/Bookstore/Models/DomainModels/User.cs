using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Models.DomainModels
{
    public class User : IdentityUser
    {
        [NotMapped]

        public IList<string> RoleNames { get; set; }
    }
}
