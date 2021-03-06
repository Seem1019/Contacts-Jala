using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.QueryFilters
{
    public class ContactQueryFilter
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
