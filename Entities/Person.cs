using Newtonsoft.Json;
namespace ManageUserApi.Entities
{
    public class Person
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Role Role { get; set; }
    }
}
