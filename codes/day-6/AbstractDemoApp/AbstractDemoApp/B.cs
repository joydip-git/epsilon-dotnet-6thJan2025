namespace AbstractDemoApp
{
    //abstract class B : A
    class B : A
    {
        string name = string.Empty;

        public B() { }
        public B(int id, string name) : base(id)
        {
            this.name = name;
        }

        //overriding base class "virtual" method "Show"
        public override string Show()
        {
            return $"Id:{Id},Name={name}";
        }

        //overriding base class "abstract" method "GetInfo"
        public override string GetInfo()
        {
            return $"Id:{Id},Name={name}";
        }

        //overriding base class "abstract" property "Name"
        public override string Name
        {
            get => name;
            set => name = value;
        }
    }

}
