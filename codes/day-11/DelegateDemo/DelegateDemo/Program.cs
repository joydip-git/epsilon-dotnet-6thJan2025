namespace DelegateDemo;

class Program
{

    static void Main()
    {
        Console.WriteLine("Hello,Delegates!");

        //2. create a instance of a delegate to refer method(s)
        // while creating instance of a delegate you MUST pass the reference of method (name of the method)

        //2.a. is the EditDocument method of DocumentManager class is instance method? -> create an instance of DocumentManager class. pass the method name along with the reference variable for that instance to the delegate constructor
        DocumentManager documentManager = new();
        DocumentDelegate editDocDelegate = new(documentManager.EditDocument);

        //2.b. is the EditDocument method of DocumentManager class is static method? -> do not create the instance of the class. Simply pass the method name along with class name to delegate constructor
        DocumentDelegate createDocDelegate = new(DocumentManager.CreateDocument);

        //3. invoke the delegate to invoke the method(s)

        //bool editStatus = editDocDelegate("path");
        //Console.WriteLine(editStatus ? "edited" : "not edited");

        //or using Invoke method of delegate object

        //bool createStatus = createDocDelegate.Invoke("path");
        //Console.WriteLine(createStatus ? "created" : "not created");


        //pass that delegate to the PrintDocument method
        ManageDocument(editDocDelegate);
        ManageDocument(createDocDelegate);
    }

    static void ManageDocument(DocumentDelegate documentDelegate)
    {
        bool status = documentDelegate("path");
        Console.WriteLine(status ? "completed" : "not completed");
    }
}


