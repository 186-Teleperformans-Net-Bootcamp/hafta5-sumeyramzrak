
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("Requests")]
    public class FriendRequest : EntityBase
    {
        public Guid User1ID { get; set; }

        public Guid FollowingID { get; set; }

        public bool IsAccepted { get; set; }

        //[ForeignKey(nameof(UserID))]
        //public User ID { get; set; }
    }
}
