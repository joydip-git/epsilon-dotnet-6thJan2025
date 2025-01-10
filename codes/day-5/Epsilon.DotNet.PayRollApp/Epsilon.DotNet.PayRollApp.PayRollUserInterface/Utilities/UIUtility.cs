using Epsilon.DotNet.PayRollApp.Models;

namespace Epsilon.DotNet.PayRollApp.PayRollUserInterface.Utilities
{
    static class UIUtility
    {
        public static int GetRecordCount()
        {
            Console.Write("how many records? ");
            return int.Parse(Console.ReadLine());
        }

        public static void SaveRecordsInStorage(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Employee employee = CreateEmployee();
                employees[i] = employee;
            }
        }
        private static Employee CreateEmployee()
        {
            Console.Write("enter id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("enter name: ");
            string name = Console.ReadLine();

            Console.Write("enter basic: ");
            decimal basic = decimal.Parse(Console.ReadLine());

            Console.Write("enter da: ");
            decimal da = decimal.Parse(Console.ReadLine());

            Console.Write("enter hra: ");
            decimal hra = decimal.Parse(Console.ReadLine());

            //Employee employee = new Employee(id, name, basic, da, hra);
            Employee employee = new(id, name, basic, da, hra);
            employee.CalculateSalary();
            return employee;
        }
        public static void PrintSalary(Employee[] employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Total Salary of {employee.Name} is {employee.TotalPay}");
            }
        }
    }
}
