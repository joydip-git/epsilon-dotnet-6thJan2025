namespace StaticPolymorphismApp
{
    internal class Person
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public static bool operator >(Person leftPerson, Person rightPerson)
        {
            return leftPerson.id > rightPerson.id;
        }
        public static bool operator <(Person leftPerson, Person rightPerson)
        {
            return leftPerson.id < rightPerson.id;
        }
        public static bool operator ==(Person leftPerson, Person rightPerson)
        {
            return IsEqual(leftPerson, rightPerson);
        }
        public static bool operator !=(Person leftPerson, Person rightPerson)
        {
            return !IsEqual(leftPerson, rightPerson);
        }

        public static bool IsEqual(Person leftPerson, Person rightPerson)
        {
            if (!(leftPerson.id == rightPerson.id))
                return false;

            if (!leftPerson.firstName.Equals(rightPerson.firstName)) return false;

            if (!leftPerson.lastName.Equals(rightPerson.lastName))
                return false;

            return true;
        }
    }
}
