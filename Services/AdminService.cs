using ManageUserApi.Context;
using ManageUserApi.Context.Interfaces;
using ManageUserApi.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ManageUserApi.Services
{
    public class AdminService
    {
        IUserRepository _adminRepository;
        public AdminService(IUserRepository userRepository)
        {
            _adminRepository = userRepository;
        }

        public List<User> GetUsersList()
        {
           return _adminRepository.GetAll();
        }

        public bool EnableUser(string id)
        {
            User user = _adminRepository.GetByID(id);

            if (user == null)
                return false;

            user.HaveAccess = true;
            return true;
        }

        public bool DisableUser(string id)
        {
            User user = _adminRepository.GetByID(id);

            if (user == null)
                return false;

            user.HaveAccess = false;
            return true;
        }

        public bool DeleteUser(string id)
        {
            try
            {
                _adminRepository.Delete(id);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
                
        }
    }
}
