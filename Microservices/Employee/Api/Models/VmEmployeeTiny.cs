namespace APIS.Models
{
    public class VmEmployeeTiny
    {
        public int id { get; set; }
        public string? userName { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public System.DateTime creationDate { get; set; }
        public bool isActive { get; set; }
    }
}
