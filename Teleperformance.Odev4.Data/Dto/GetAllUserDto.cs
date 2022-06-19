using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Odev4.Data.Dto
{
    public class GetAllUserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
