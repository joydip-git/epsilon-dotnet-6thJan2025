namespace AbstractDemoApp
{
    abstract class A
    {
        private int id;

        public A() { }
        public A(int id) { this.id = id; }

        public int Id { set => id = value; get => id; }

        public override string ToString()
        {
            return $"Id:{id}";
        }

        public virtual string Show()
        {
            return $"Id:{id}";
        }

        //abstract method
        public abstract string GetInfo();

        //abstract property
        public abstract string Name
        {
            get;
            set;
        }
    }
}
