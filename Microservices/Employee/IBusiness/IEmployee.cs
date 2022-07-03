using Models;
namespace IBusiness
{
    public interface IEmployee
    {
        List<Employee> GetAll();
        Employee Save(Employee Employee);
        Employee Get(int id);
    }
}