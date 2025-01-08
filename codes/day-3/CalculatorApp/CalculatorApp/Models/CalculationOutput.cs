namespace CalculatorApp.Models
{
    //Data Transfer Object (DTO)
    class CalculationOutput
    {
        private readonly int result;
        private readonly string method = string.Empty;

        public CalculationOutput() { }
        public CalculationOutput(int result, string method)
        {
            this.result = result;
            this.method = method;
        }

        public int Result { get { return result; } }
        public string Method => method;
    }
}
