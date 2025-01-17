//top-level statement => a template where you don not need to create explicit class (by default Program class) with Main method
//the following code is written inside Main method
using FurtherNewFeaturesInCSharp;
using FurtherNewFeaturesInCSharp.Models;

Person? anilPerson = new() { Name = "Anil", Id = 1 };
Console.WriteLine(anilPerson?.Name);

Product dellXps = new() { Id = 1, Name = "Dell XPS 15", Description = "new 15 inch laptop from dell xps series", Price = 150000.55M };
Product hpProbook = new() { Id = 2, Name = "HP Probook 13", Description = "new 13 inch laptop from hp probook series", Price = 130000.55M };
Product lenovoThinkpad = new() { Id = 3, Name = "Lenovo Thinkpad", Description = "new 14 inch laptop fromlenovo thinkpad series", Price = 155000.55M };

Product[] products = [dellXps, hpProbook, lenovoThinkpad];

decimal? total = 0;
foreach (var item in products)
{
    total += item.Price;
}
for (int i = 0; i < products.Length; i++)
{
    for (int j = i + 1; j < products.Length; j++)
    {
        if (products[i].Price > products[j].Price)
        {
            Product temp = products[i];
            products[i] = products[j];
            products[j] = temp;
        }
    }
}
//decimal? avg = total / products.Length;
//decimal? max = products[products.Length - 1].Price;
//decimal? min = products[0].Price;
var statistics = new { Average = total / products.Length, Maximum = products[products.Length - 1].Price, Minimum = products[0].Price };
Console.WriteLine($"Avg Price={statistics.Average}, Max Price={statistics.Maximum}, Minimum={statistics.Minimum}");

//implicitly typed local variable (3.0)
//must assign value to implicitly typed local variable as C# infers the data type of the variable from the assigned value
//var is JUST a keyword, not a data type
var x = 10;
Console.WriteLine(x);

//implicitly typed local array variable
var numbers = new[] { 1, 2, 3, 4 };
Console.WriteLine(numbers[2]);

//anonymous type (3.0) => a type which is anonymous -> unknown
//this feature is used to create read-only type object
//even anonymous types do inherit from Object class
//doctor => implicitly typed local variable (as no class name available)
//FirstName, LastName, Profession => Imaginary properties (read-only) of the unknown class name
//object initializer
var doctor = new { FirstName = "Anil", LastName = "Gupta", Profession = "GP" };

//the properties are read-only
//doctor.FirstName = "";
Console.WriteLine($"FullName={doctor.FirstName + " " + doctor.LastName}, Profession={doctor.Profession}");
/*
 * class AnonymousType_01
 * {
 *   //private string firstName;
 *   public string FirstName{ get; set;}
 *   //private string lastName;
 *   public string LastName{ get; set;}
 * }
 */

Print();
//Print is a local static function of invisible Main method
static void Print()
{
    Console.WriteLine("Hello, World!");
}

/*
namespace FurtherNewFeaturesInCSharp;

internal class Program
{
    public static void Main()
    {
        //Program.Print();
        Print();

        //local function (8.0)
        //note: local functions can be static
        //can't be used outside the parent function
        //void Print()
        static void Print()
        {
            Console.WriteLine("Hello, World!");
        }
    }
    static void Show()
    {
        //Print is local to Main method, only available within Main method
        //Print();
    }
    //private static void Print()
    //{
    //    Console.WriteLine("Hello, World!");
    //}
}
*/


