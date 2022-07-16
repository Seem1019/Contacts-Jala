using Contacts.Core.Entities;
using Contacts.Core.Exceptions;
using Contacts.Core.Interfaces;

namespace Contacts.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            var user = await _unitOfWork.SecurityRepository.GetUserByUsername(security.UserName);
            if (user is not null)
            {
                throw new BusinessException("Username already exist");
            } 
            await _unitOfWork.SecurityRepository.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
