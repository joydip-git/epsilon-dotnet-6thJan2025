using System.Collections;
using System.Collections.Generic;

Console.WriteLine("Hello to Collections....!");

//UseArrayList();
UseList();
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
    list.Add(2);
    list.Add(4);
    //you are actually adding the ASCII vakue of the char
    list.Add('a');

    list.Insert(2, 20);

    Console.WriteLine("value before deleteion\n");
    for (int i = 0; i < list.Count; i++)
    {
        Console.WriteLine(list[i]);
    }

    list.Remove(2);
    list.RemoveAt(1);

    Console.WriteLine("\nvalue after deleteion\n");
    foreach (int item in list)
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