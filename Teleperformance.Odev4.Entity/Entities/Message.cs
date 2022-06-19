
using System.ComponentModel.DataAnnotations.Schema;
using Teleperformance.Odev4.Common;

namespace Teleperformance.Odev4.Entity
{
    [Table("Messages")]
    public class Message:EntityBase
    {
        public Guid FromID { get; set; }

        public string Content { get; set; }

        public Guid ToID { get; set; }
        
        public int MType { get; set; }
        
        public bool IsPublic { get; set; }

        public int SendType { get; set; }

        [ForeignKey(nameof(MType))]
        public MessageType TypeID { get; set; }

        [ForeignKey(nameof(SendType))]
        public MessageSendType SendTypeID { get; set; }
    }
}
