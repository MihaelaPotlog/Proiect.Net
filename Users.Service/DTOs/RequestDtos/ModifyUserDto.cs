namespace Users.Service.DTOs
{
    public class ModifyUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string[] AddedTechnologiesNames { get; set; }
        public string[] RemovedTechnologiesNames { get; set; }
    }
}
