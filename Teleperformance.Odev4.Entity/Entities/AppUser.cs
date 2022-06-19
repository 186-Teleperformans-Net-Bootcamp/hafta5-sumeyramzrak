using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance.Odev4.Data.Context
{
    [Table("AppUsers")]
    public class AppUser: IdentityUser
    {
        public Guid AppUserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}





