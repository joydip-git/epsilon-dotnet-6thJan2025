namespace PeronLibrary;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name:{Name}, Salary:{Salary}";
    }

    //public static bool operator >(Person a, Person b)
    //{
    //    return true;
    //}
    //public static bool operator <(Person a, Person b)
    //{
    //    return true;
    //}
}
