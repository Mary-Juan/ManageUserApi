using ManageUserApi.Context.Interfaces;
using ManageUserApi.Context;
using ManageUserApi.Entities;
using ManageUserApi.DTOs;
using System;

namespace ManageUserApi.Services
{
    public class UserService
    {
        private readonly string _filePath;
        IPersonRepository _personRepository;
        public UserService(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("FilePath");
            _personRepository = new PersonRepository(_filePath);
        }

        public Role? Login(LoginDto login)
        {
            List<Person> people = _personRepository.GetAll();
            Person person = people.FirstOrDefault(p => p.UserName == login.UserName && p.Password == login.Password);
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
                _personRepository.Create(user);
                _personRepository.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
