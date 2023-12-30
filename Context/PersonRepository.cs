using ManageUserApi.Context.Interfaces;
using ManageUserApi.Entities;

namespace ManageUserApi.Context
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _filePath;

        private readonly List<Person> _people;

        public PersonRepository(string filePath)
        {
            _filePath = filePath;
            _people = Serialization.DeserializeFromJsonFile(_filePath);
        }

        public Person Create(Person person)
        {
            try
            {
                _people.Add(person);
                return person;
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
                Person person = GetByID(id);
                person.IsDeleted = true;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Person> GetAll()
        {
            return _people;
        }

        public Person GetByID(string id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            Serialization.SerializeToJsonFile(_filePath, _people);
        }

        public Person Update(Person person)
        {
            try
            {
                Person intendedPerson = GetByID(person.Id);
                intendedPerson.UserName = person.UserName;
                intendedPerson.Password = person.Password;
                intendedPerson.Email = person.Email;
                intendedPerson.Role = person.Role;
                return intendedPerson;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
