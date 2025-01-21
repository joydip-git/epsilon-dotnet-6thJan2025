namespace DelegateDemo
{
    //1. declare a delegate which can store "reference" of the EditDocument method, so that using that reference (or delegate) the EditDocument method can be called

    //Note: a delegate declaration should be same as that of the method(s) that you would like to store reference(s) of and invoke
    //return type as well as data type, number and position of the arguments of the method(s) and the delegate should match in order for the method(s) to be referred by the delegate and invoked by the delegate
    //ONLY those methods whose signature matches to that of the delegate can be called by the delegate
    //syntax: 
    //<access-specifier> delegate <return-type> delegate-name(arguments)

    public delegate bool DocumentDelegate(string filePath);
}
