
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("Friendships")]
    public class Friendship : EntityBase
    {
        public Guid Person1 { get; set; }

        public Guid Person2 { get; set; }

        //[ForeignKey(nameof(Person1))]
        //public User ID { get; set; }
    }
}
