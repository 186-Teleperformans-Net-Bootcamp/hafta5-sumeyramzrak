
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("Comments")]
    public class Comment : EntityBase
    {
        public Guid MessageID { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(MessageID))]
        public Message ID { get; set; }
    }
}
