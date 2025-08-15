namespace APIApplication.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string ResourceKey { get; set; } // e.g., "Reports", "Settings"

        public string ResourceController { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
