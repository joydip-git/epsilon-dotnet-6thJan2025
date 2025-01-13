namespace AbstractDemoApp
{
    abstract class Messenger : IMessenger, IDeliveryPerson
    {
        private string _name = string.Empty;

        public Messenger()
        {

        }
        public Messenger(string name)
        {
            this._name = name;
        }

        //public abstract string Name { set; get; }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public abstract string DeliverMessage();
        //public string DeliverMessage()
        //{
        //    return $"Hello {_name}";
        //}
    }
}
