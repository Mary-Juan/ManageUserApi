using ManageUserApi.Context;
using ManageUserApi.Context.Interfaces;
using ManageUserApi.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ManageUserApi.Services
{
    public class AdminService
    {
        private readonly string _filePath;
        IUserRepository _adminRepository;
        public AdminService(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("FilePath");
            _adminRepository = new UserRepository(_filePath);
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
