namespace PeronLibrary;

public class Person //:Object
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public override string ToString()
    {
        var info = $"Id: {Id}, Name:{Name}, Salary:{Salary}";
        return info;
    }
    //object class's Equals method
    // public virtual int Equals(object? obj)
    // {
    //    if(obj == null) returns false;    
    //    if(this != obj) returns fale;
    //    return true;
    // }

    //object class's GetHashCode method
    // public virtual int GetHashCode()
    // {
    //     var hash = this.GetHashCode()
    //     return hash;
    // }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj == this) return true;
        if (obj is not Person) return false;

        Person other = (Person)obj;
        if (!(this.Id.Equals(other.Id))) return false;

        if (!(this.Name.Equals(other.Name))) return false;

        if (!(this.Salary.Equals(other.Salary))) return false;

        return true;
    }
    public override int GetHashCode()
    {
        const int prime = 31;
        int hash = this.Id.GetHashCode() * prime;
        hash *= (this.Name != null ? this.Name.GetHashCode() : prime);
        hash *= this.Salary.GetHashCode();
        return hash;
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
