namespace ObjectClassMethodsApp
{
    internal class Person //:Object
    {
        int id;
        string name = string.Empty;
        decimal salary;

        public Person()
        {

        }

        public Person(int id, string name, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Salary { get => salary; set => salary = value; }

        //you are providing a new implementation of the ToString() method of base class, Object, and you want the child class method to be invoked always
        public override string ToString()
        {
            return $"Id:{this.id},Name:{this.name},Salary:{this.salary}";

            //base class ToString() method code
            //return this.GetType().FullName;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = this.id.GetHashCode() * prime;
            hash = this.name.GetHashCode() * hash;
            hash = this.salary.GetHashCode() * hash;
            return hash;
        }

        public override bool Equals(object? obj)
        {
            //whether the null reference has been passed or not
            if (obj == null) return false;

            //whether both reference variable (this and obj) are referring to the same instance or not
            if (this == obj) return true;

            //whether the data type of object is Person or not
            //if (!(obj is Person)) return false;

            //equivalent to this following code:
            //if (obj.GetType()!= typeof(Person)) return false;

            //using pattern matching
            if (obj is not Person) return false;

            //down-casting (taking the reference of the actual (child) class object back to its reference variable from base class reference variable)
            Person other = (Person)obj;
            if (this.id != other.id) return false;

            if (this.name != other.name) return false;

            if (this.salary != other.salary) return false;

            return true;
        }

        public static bool operator == (Person a, Person b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Person a, Person b)
        {
            return !a.Equals(b);
        }
    }
}
