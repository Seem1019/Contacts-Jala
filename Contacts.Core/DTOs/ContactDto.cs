using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.DTOs
{
    public class ContactDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
