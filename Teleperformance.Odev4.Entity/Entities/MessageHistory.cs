
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("MessageHistory")] // Mesaj güncellendiğinde ilk halinin tutulduğu tablo
    public class MessageHistory : EntityBase
    {
        public Guid MessageID { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(MessageID))]
        public Message ID { get; set; }

    }
}
