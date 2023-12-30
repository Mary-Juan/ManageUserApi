using ManageUserApi.Context.Interfaces;
using ManageUserApi.Entities;

namespace ManageUserApi.Context
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath;

        private readonly List<User> _users;

        public UserRepository(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("FilePath");
            _users = Serialization.DeserializeFromJsonFile(_filePath);
        }

        public User Create(User user)
        {
            try
            {
                _users.Add(user);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(string id)
        {
            try
            {
                User user = GetByID(id);
                user.IsDeleted = true;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetByID(string id)
        {
            return _users.FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            Serialization.SerializeToJsonFile(_filePath, _users);
        }

        public User Update(User user)
        {
            try
            {
                User intendedUser = GetByID(user.Id);
                intendedUser.UserName = user.UserName;
                intendedUser.Password = user.Password;
                intendedUser.Email = user.Email;
                intendedUser.Role = user.Role;
                return intendedUser;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
