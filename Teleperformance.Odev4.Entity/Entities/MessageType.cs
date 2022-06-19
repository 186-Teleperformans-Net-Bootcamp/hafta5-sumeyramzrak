
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teleperformance.Odev4.Entity
{
    [Table("MessageTypes")] //Dosya tipi
    public class MessageType 
    {
        [Key]
        public int TypeID { get; set; }
        
        public string Type { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
