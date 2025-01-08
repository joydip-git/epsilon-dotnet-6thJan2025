namespace CalculatorApp
{
    class CalcRecord
    {
        private int result;
        private string method;

        public CalcRecord()
        {
            //method=null;
            //result=0;
        }
        public CalcRecord(int result, string method)
        {
            this.result = result;
            this.method = method;
        }

        //public void SetReult(int value) => this.result = value;
        //public int GetResult() => result;

        //property or property function
        public int Result
        {
            //set accessor
            set => result = value;
            //get accesor
            get => result;
        }

        //public void SetMethod(string method) => this.method = method;
        //public string GetMethod() => method;
        public string Method
        {
            set => method = value;
            get => method;
        }
    }
}
