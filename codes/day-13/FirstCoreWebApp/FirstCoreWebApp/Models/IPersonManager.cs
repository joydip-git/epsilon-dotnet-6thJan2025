
namespace FirstCoreWebApp.Models
{
    public interface IPersonManager
    {
        Person? Get(int id);
        IEnumerable<Person> GetAll();
        bool Insert(Person person);
        bool Remove(int id);
        bool Update(int id, Person person);
    }
}