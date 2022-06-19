
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance.Odev4.Entity
{
    [Table("MessageSendTypes")] // Erişilebilirlik
    public class MessageSendType
    {
        [Key]
        public int SendTypeID { get; set; }
       
        public string Type { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
