using PeronLibrary;
using System.Collections;
//using System.Collections.Generic;

Console.WriteLine("Hello to Collections....!");

//UseArrayList();
//UseList();
//UseSet();
//UseDictionary();
//UseSortedList();
//UseStack();
UseQueue();

void UseStack()
{
    //LIFO data structure
    Stack<int> numbers = [];
    numbers.Push(1);
    numbers.Push(2);
    numbers.Push(3);
    numbers.Push(4);

    //no indexer in Stack, hence no for loop
    foreach (var item in numbers)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine("\nusing enumerator\n");
    numbers.Pop();
    IEnumerator<int> enumerator = numbers.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }

    Console.WriteLine($"Top element: {numbers.Peek()}");
}

void UseQueue()
{
    //FIFO data structure
    Queue<int> numbers = [];
    numbers.Enqueue(1);
    numbers.Enqueue(2);
    numbers.Enqueue(3);
    numbers.Enqueue(4);

    //no indexer in Queue, hence no for loop
    foreach (var item in numbers)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine("\nusing enumerator\n");
    numbers.Dequeue();
    IEnumerator<int> enumerator = numbers.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
}

static void UseArrayList()
{
    int x = 12;
    //boxing: converting value type to reference type
    object objX = x;
    //unboxing: converting already boxed value back to value type (from reference type)
    int y = (int)objX;
    Console.WriteLine(y);

    ArrayList arrayList = new();
    arrayList.Add(objX);        //0
    arrayList.Add('a');         //2
    arrayList.Add("epsilon");   //3
    arrayList.Add(12.34M);      //4

    //index position <= number of the elements in the arraylist
    arrayList.Insert(4, 100.56D);//5
    arrayList.Insert(1, "bangalore");//1

    for (int i = 0; i < arrayList.Count; i++)
    {
        Console.WriteLine($"value at arrayList[{i}]: {arrayList[i]}");
    }

    Console.WriteLine($"capacity of arr is: {arrayList.Capacity}");

    arrayList.Remove('a');
    arrayList.RemoveAt(3);
    arrayList.RemoveAt(1);

    Console.WriteLine($"capacity of arr is: {arrayList.Capacity}");

    Console.WriteLine("\nusing foreach\n");
    foreach (object obj in arrayList)
    {
        Console.WriteLine(obj);
    }

    Console.WriteLine($"index: {arrayList.IndexOf("epsilon")}");
    //arrayList.RemoveRange(2, 2);

    //in order to the Sort method to work, you need to have similar type of data
    //ArrayList's Sort() method expects the all the other values should be of similar type as that of the first value that was added
    //arrayList.Sort();

    IEnumerator enumerator = arrayList.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }

}

static void UseList()
{
    List<int> list = new();
    //List<int> list = [];
    list.Add(1);
    list.Add(12);
    list.Add(12);
    list.Add(2);
    list.Add(4);
    //you are actually adding the ASCII vakue of the char
    list.Add('a');

    list.Insert(2, 20);

    Console.WriteLine("value before deleteion\n");
    for (var i = 0; i < list.Count; i++)
    {
        Console.WriteLine(list[i]);
    }

    list.Remove(2);
    list.RemoveAt(1);

    Console.WriteLine("\nvalue after deleteion\n");
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }

    list.Sort();
    /*
    for (int i = 0; i < list.Count; i++)
    {
        for (int j = i + 1; j < list.Count; j++)
        {
            //if (list[i] > list[j])
            if (list[i].CompareTo(list[j]) > 0)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
    */

    Console.WriteLine("\nvalue after sorting\n");
    IEnumerator<int> ie = list.GetEnumerator();
    while (ie.MoveNext())
    {
        Console.WriteLine(ie.Current);
    }
}

static void UseSet()
{
    HashSet<int> setOfNumbers = new HashSet<int>();
    setOfNumbers.Add(1);  //1.GetHasCode() => 1234
    setOfNumbers.Add(12); //12.GetHasCode() => 2345
    setOfNumbers.Add(2);  //2.GetHasCode() => 4321
    setOfNumbers.Add(12); //12.GetHasCode() => 2345 and 12.Equals(12)

    //setOfNumbers.Remove(2);

    //NO for loop to iterate through the set, since HashSet does not have indexer
    foreach (var item in setOfNumbers)
    {
        Console.WriteLine(item);
    }

    // HashSet<Person> people = new HashSet<Person>() {
    //     new Person(){ Id=3,Name="joydip", Salary=1000 },
    //     new Person(){ Id=1,Name="sunil", Salary=2000 },
    //     new Person(){ Id=2,Name="anil", Salary=3000 }
    //};
    // HashSet<Person> people = new() {
    //     new Person(){ Id=3,Name="joydip", Salary=1000 },
    //     new Person(){ Id=1,Name="sunil", Salary=2000 },
    //     new Person(){ Id=2,Name="anil", Salary=3000 }
    //};

    var joydipPerson = new Person() { Id = 3, Name = "joydip", Salary = 1000 };
    var sunilPerson = new Person() { Id = 1, Name = "sunil", Salary = 2000 };
    var anilPerson = new Person() { Id = 2, Name = "anil", Salary = 3000 };

    //following two instances will NOT be added as they are duplicate
    //var anilPerson = joydipPerson; -> reference to same object
    //var anilPerson = new Person() { Id = 3, Name = "joydip", Salary = 1000 }; -> different reference but having same values for all properties

    //collection initializer
    HashSet<Person> people = [
       joydipPerson,
        //joydipPerson.GetHashCode() => 1334
       sunilPerson,
        //sunilPerson.GetHashCode() => 4331
        anilPerson
        //anilPerson.GetHashCode() => 3341

        //anilPerson.GetHashCode() => 1334 and joydipPerson.Equals(anilPerson)
    ];
    foreach (Person item in people)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("\niterating using enumerator\n");
    IEnumerator<Person> enumerator = people.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }

}

static void UseDictionary()
{
    //Dictionary<string,string> dictionary = new Dictionary<int,string>();
    //Dictionary<string, string> dictionary = new();
    Dictionary<string, string> dictionary = [];
    dictionary.Add("1", "epsilon");
    dictionary.Add("0", "bangalore");

    //dictionary DOES NOT sort the keys

    //if the key does not exist the key and the value will be added
    dictionary["2"] = "Karnataka";

    //will update the value for the key, if the same key already exists
    dictionary["0"] = "bengaluru";

    //will throw an exception if same key already exists
    //dictionary.Add("0","India"); 

    foreach (KeyValuePair<string, string> item in dictionary)
    {
        Console.WriteLine($"{item.Key} -> {item.Value}");
    }

    //remove a value using its key
    dictionary.Remove("1");

    Console.WriteLine("\nusing enumerator\n");
    IEnumerator<KeyValuePair<string, string>> enumerator = dictionary.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine($"{enumerator.Current.Key} -> {enumerator.Current.Value}");
    }

    //Console.WriteLine($"Contains key:0? {dictionary.ContainsKey("0")}, value: {dictionary.GetValueOrDefault("0")}");
    //or
    //Console.WriteLine($"Contains key:3? {dictionary.ContainsKey("3")}, value: {dictionary["3"]}");

    Console.WriteLine($"Contains key:3? {dictionary.ContainsKey("3")}");

    //will throw exception if the key does not exist
    //Console.WriteLine($"value: {dictionary["3"]}");

    //will NOT throw exception if the value for the given key does not exist
    Console.WriteLine($"Contains Value? {dictionary.ContainsValue("3")}");

}

static void UseSortedList()
{
    //SortedList<string,string> sortedList = new SortedList<int,string>();
    //SortedList<string, string> sortedList = new();
    SortedList<string, string> sortedList = [];
    sortedList.Add("1", "epsilon");
    sortedList.Add("0", "bangalore");

    //Sorted List DOES NOT sort the keys by default

    //if the key does not exist the key and the value will be added
    sortedList["2"] = "Karnataka";

    //will update the value for the key, if the same key already exists
    sortedList["0"] = "bengaluru";

    //will throw an exception if same key already exists
    //sortedList.Add("0","India"); 

    foreach (KeyValuePair<string, string> item in sortedList)
    {
        Console.WriteLine($"{item.Key} -> {item.Value}");
    }

    //remove a value using its key
    sortedList.Remove("1");

    Console.WriteLine("\nusing enumerator\n");
    IEnumerator<KeyValuePair<string, string>> enumerator = sortedList.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine($"{enumerator.Current.Key} -> {enumerator.Current.Value}");
    }

    //Console.WriteLine($"Contains key:0? {sortedList.ContainsKey("0")}, value: {sortedList.GetValueOrDefault("0")}");
    //or
    //Console.WriteLine($"Contains key:3? {sortedList.ContainsKey("3")}, value: {sortedList["3"]}");

    Console.WriteLine($"Contains key:3? {sortedList.ContainsKey("3")}");

    //will throw exception if the key does not exist
    //Console.WriteLine($"value: {sortedList["3"]}");

    //will NOT throw exception if the value for the given key does not exist
    Console.WriteLine($"Contains Value? {sortedList.ContainsValue("3")}");

}