namespace AbstractDemoApp
{
    internal class Postman : Messenger
    {
        public Postman()
        {

        }
        public Postman(string name) : base(name)
        {

        }
        public override string DeliverMessage()
        {
            return $"{Name} who is a {this.GetType().Name} is delivering letter";
            //return $"{Name} who is a {typeof(Postman).Name} is delivering letter";
            //return $"{Name} who is a {nameof(Postman)} is delivering letter";
        }
    }
}
