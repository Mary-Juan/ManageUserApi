using ManageUserApi.Context;
using ManageUserApi.Context.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ManageUserApi.Services
{
    public class AdminService
    {
        private readonly string _filePath;
        IPersonRepository _adminRepository;
        public AdminService(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("FilePath");
            _adminRepository = new PersonRepository(_filePath);
        }


    }
}
