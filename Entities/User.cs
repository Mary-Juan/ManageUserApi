namespace ManageUserApi.Entities
{
    public class User : Person
    {
        public bool HaveAccess { get; set; } = true;
    }
}
