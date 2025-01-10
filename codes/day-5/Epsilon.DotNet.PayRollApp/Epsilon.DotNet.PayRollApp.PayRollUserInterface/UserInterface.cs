using Epsilon.DotNet.PayRollApp.Models;
using static Epsilon.DotNet.PayRollApp.PayRollUserInterface.Utilities.UIUtility;

namespace Epsilon.DotNet.PayRollApp.PayRollUserInterface
{
    class UserInterface
    {
        static void Main()
        {
            int recordCount = GetRecordCount();
            Employee[] employees = new Employee[recordCount];
            SaveRecordsInStorage(employees);
            PrintSalary(employees);

            //object[] arr = [1, 'a', 12.34D, 23.45M, 56.78F, "epsilon", new Employee()];
        }
    }
}
