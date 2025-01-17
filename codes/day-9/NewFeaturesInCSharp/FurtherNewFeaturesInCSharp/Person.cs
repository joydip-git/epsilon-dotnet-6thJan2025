namespace FurtherNewFeaturesInCSharp.Models
{
    class Person
    {
        //int id;
        string? name;

        public Person()
        {

        }

        public Person(int id, string? name)
        {
            //this.id = id;
            //this.name = name;
            this.Id = id;
            this.Name = name;
        }

        //public required int Id { get => id; set => id = value; }

        //auto-implemented property (3.0)
        //the syntax is very similar to abstract property =>
        //public abstract int Id { set; get; }
        //it is not an abstract property (as you might think since there is no code for set and get)
        // when you compile this code using compiler (C# or Roslyn), here the invisible private data member witll be created for you and set and get accessor will use that invisible private data member
        //use automatic property when there is only one line of code for both set and get

        public required int Id { set; get; }
        //public int Id { set; get; }

        // private int _IdValue;
        // public required int Id { set=> _IdValue=value; get=>_idValue; }

        //Name should not be an automatic property as you have extra lines of custom code
        public string? Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
            }
        }
    }
}
