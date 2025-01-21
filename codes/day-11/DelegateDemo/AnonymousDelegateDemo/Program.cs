using System.Linq.Expressions;
using System;

namespace AnonymousDelegateDemo;

delegate void Worker(string name);

class Program
{
    public static void Main()
    {
        Worker callWorker = new(CallMe);
        callWorker("joydip");

        //anonymous method -> (string name){};
        //void InviteFriend(string friendName) => delegate(string friendName)
        //Note: anonymous methods are non-static
        Worker inviteWorker = new(
            //anonymous method
            delegate (string friendName)
            {
                Console.WriteLine($"{friendName} you are invited to the weekend party...");
            }
        );

        //or (method-group conversion syntax)
        Worker seeOfWorker = delegate (string friendName)
        {
            Console.WriteLine($"see you {friendName} agin...");
        };

        //or using Lambda expression [expression body syntax for an anonymous method]

        //Lambda operator: => 
        //expression: (arguments of the method) => single line expression body
        //or
        //expression: (arguments of the method) => { multi-line code}

        //single-line code
        //Worker greetWorker = (string friendName) => Console.WriteLine
        //($"welcome {friendName}");

        //multi-line code
        Worker greetWorker = (string friendName) =>
        {
            if (string.IsNullOrEmpty(friendName))
                throw new ArgumentException($"{nameof(friendName)} is either null or empty");

            Console.WriteLine($"welcome {friendName}");
        };

        //invoking anomymous method
        inviteWorker("joydip");
        seeOfWorker("joydip");
        greetWorker("joydip");
    }
    static void CallMe(string name)
    {
        Console.WriteLine($"Please call me {name}");
    }
}



/*
Worker inviteWorker = new(InviteFriend); 
static void InviteFriend(string name)
{
    Console.WriteLine($"{name} you are invited to the weekend party...");
}
 */



