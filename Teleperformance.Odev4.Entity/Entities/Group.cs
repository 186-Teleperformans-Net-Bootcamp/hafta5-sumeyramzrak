
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("Groups")]
    public class Group : EntityBase
    {
        public Group()
        {
            Members = new HashSet<GroupMember>();
        }

        public string GroupName { get; set; }
        public ICollection<GroupMember> Members { get; set; }
    }
}
