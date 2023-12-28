using ManageUserApi.Entities;

namespace ManageUserApi.Context.Interfaces
{
    public interface IPersonRepository
    {
        public Person Create(Person person);
        public Person Update(Person person);
        public bool Delete(string id);
        public List<Person> GetAll();
        public Person GetByID(string id);
        public void SaveChanges();
    }
}
