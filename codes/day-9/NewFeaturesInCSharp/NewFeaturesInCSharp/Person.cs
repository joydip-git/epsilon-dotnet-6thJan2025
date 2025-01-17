namespace NewFeaturesInCSharp
{
    class Person
    {
        int id;
        string name = string.Empty;
        double[]? marks;

        public Person()
        {

        }

        public Person(int id, string name, double[]? marks = null)
        {
            this.id = id;
            this.name = name;
            this.marks = marks;
        }
        //the vlaue must be assigned (required)
        //required keyword must be used with a public member
        public required int Id { get => id; set => id = value; }
        public required string Name { get => name; set => name = value; }
        public double[]? Marks { get => marks; set => marks = value; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;

            //nameof operator (6.0)
            if (obj is not Person)
                throw new ArgumentException($"argument obj is not of type {nameof(Person)}");

            //if (obj is not Person)
            //    throw new ArgumentException($"argument obj is not of type Person");

            Person other = (Person)obj;
            if (this.id != other.id)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            return this.id.GetHashCode() * prime;
        }
    }
}
