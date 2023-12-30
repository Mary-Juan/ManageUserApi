using ManageUserApi.Context.Interfaces;
using ManageUserApi.Context;
using ManageUserApi.Entities;
using ManageUserApi.DTOs;
using System;

namespace ManageUserApi.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Role? Login(LoginDto login)
        {
            List<User> users = _userRepository.GetAll();
            User person = users.FirstOrDefault(p => p.UserName == login.UserName && p.Password == login.Password);
            if (person == null)
            {
                return null;
            }
            else
                return person.Role;
        }

        public bool Register(RegisterDto register)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password
            };

            try
            {
                _userRepository.Create(user);
                _userRepository.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
