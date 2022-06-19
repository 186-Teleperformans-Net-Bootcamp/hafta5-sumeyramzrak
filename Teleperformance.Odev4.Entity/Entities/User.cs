using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("Users")]
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
       
        public string Password { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime ModifiedAt { get; set; }
        
        public Guid? CreatedBy { get; set; }
        
        public Guid? ModifiedBy { get; set; }
       
    }
}