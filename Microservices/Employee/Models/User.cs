using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
    public partial class Employee
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
