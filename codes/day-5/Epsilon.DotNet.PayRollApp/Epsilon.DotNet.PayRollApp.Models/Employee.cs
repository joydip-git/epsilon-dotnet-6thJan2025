namespace Epsilon.DotNet.PayRollApp.Models
{
    public class Employee
    {
        readonly int id;
        string name = string.Empty;
        decimal basicPay;
        decimal daPay;
        decimal hraPay;
        decimal totalPay;

        public Employee()
        {

        }

        public Employee(int id, string name, decimal basicPay, decimal daPay, decimal hraPay)
        {
            this.id = id;
            this.name = name;
            this.basicPay = basicPay;
            this.daPay = daPay;
            this.hraPay = hraPay;
        }

        public int Id => id;

        public string Name { get => name; set => name = value; }
        public decimal BasicPay { get => basicPay; set => basicPay = value; }
        public decimal DaPay { get => daPay; set => daPay = value; }
        public decimal HraPay { get => hraPay; set => hraPay = value; }
        public decimal TotalPay { get => totalPay; }

        public void CalculateSalary()
        {
            totalPay = basicPay + daPay + hraPay;
        }
    }

}
