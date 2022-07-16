using Contacts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
