using Newtonsoft.Json;
namespace ManageUserApi.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool HaveAccess { get; set; } = true;
        public Role Role { get; set; } = new Role()
        {
            RoleId = 1,
            RoleTitle = "User"
        };
    }
}
