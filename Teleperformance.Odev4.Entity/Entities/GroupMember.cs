using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance.Odev4.Entity
{
    public class GroupMember
    {
        [Key]
        public int ID { get; set; }
        
        public string GroupName { get; set; }
        
        public Guid MemberID { get; set; }
        
        public DateTime? JoinedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

       public List<User> Users { get; set; }

    }
}
