using Epsilon.DotNet.PayRollApp.Models;
using static Epsilon.DotNet.PayRollApp.PayRollUserInterface.Utilities.UIUtility;

namespace Epsilon.DotNet.PayRollApp.PayRollUserInterface
{
    class UserInterface
    {
        static void Main()
        {
            Employee employee = CreateEmployee();
            Console.WriteLine($"Total Salary of {employee.Name} is {employee.TotalPay}");
        }       
    }
}
