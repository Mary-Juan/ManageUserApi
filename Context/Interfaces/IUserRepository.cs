using ManageUserApi.Entities;

namespace ManageUserApi.Context.Interfaces
{
    public interface IUserRepository
    {
        public User Create(User user);
        public User Update(User user);
        public bool Delete(string id);
        public List<User> GetAll();
        public User GetByID(string id);
        public void SaveChanges();
    }
}
