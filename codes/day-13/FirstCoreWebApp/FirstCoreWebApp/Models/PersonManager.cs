using static FirstCoreWebApp.Models.PersonRepository;

namespace FirstCoreWebApp.Models
{
    public class PersonManager : IPersonManager
    {
        public IEnumerable<Person> GetAll()
        {
            return People;
        }
        public Person? Get(int id)
        {
            return People.Where(p => p.Id == id).FirstOrDefault();
        }
        public bool Insert(Person person)
        {
            bool doesExist = People.Any(p => p.Id == person.Id);
            if (doesExist)
                return false;
            People.Add(person);
            return true;
        }
        public bool Remove(int id)
        {
            var records = People.Where(p => p.Id == id);
            if (records != null && records.Any())
            {
                return People.Remove(records.First());
            }
            else
                return false;
        }
        public bool Update(int id, Person person)
        {
            var records = People.Where(p => p.Id == id);
            if (records != null && records.Any())
            {
                var found = records.First();
                found.Name = person.Name;
                found.Salary = person.Salary;
                return true;
            }
            else
                return false;
        }
    }
}
