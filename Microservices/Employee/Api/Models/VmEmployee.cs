namespace APIS.Models
{
    public class VmEmployee
    {
        public int id { get; set; }
        public string? fullName { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public System.DateTime creationDate { get; set; }
        public int creationUser { get; set; }
        public Nullable<System.DateTime> editDate { get; set; }
        public Nullable<int> editUser { get; set; }
        public bool isActive { get; set; }
    }
}
