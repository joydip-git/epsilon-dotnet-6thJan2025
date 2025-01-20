// See https://aka.ms/new-console-template for more information

using ListItemSortingDemo;
using PeronLibrary;

Console.WriteLine("Hello, World!");

//collection initializer (3.0)
//List<Person> people = new List<Person>()
//{
//    new Person(){ Id=3,Name="joydip", Salary=1000 },
//    new Person(){ Id=1,Name="sunil", Salary=2000 },
//    new Person(){ Id=2,Name="anil", Salary=3000 },
//};
//List<Person> people = new()
//{
//    new Person(){ Id=3,Name="joydip", Salary=1000 },
//    new Person(){ Id=1,Name="sunil", Salary=2000 },
//    new Person(){ Id=2,Name="anil", Salary=3000 },
//};
List<Person> people = [
    new Person(){ Id=3,Name="joydip", Salary=1000 },
    new Person(){ Id=1,Name="sunil", Salary=2000 },
    new Person(){ Id=2,Name="anil", Salary=3000 }
];

try
{
    //people.Sort(); => expects the Person type has implemented CompareTo() method from IComparable<Person> interface

    PersonComparer personComparer = new PersonComparer();
    people.Sort(personComparer);
    //SortPeople(people);

    IEnumerator<Person> enumerator = people.GetEnumerator();
    while (enumerator.MoveNext())
    {
        Console.WriteLine(enumerator.Current);
    }
}
catch (Exception ex)
{
    //Console.WriteLine(ex.Message);
    //Console.WriteLine(ex.TargetSite);
    //Console.WriteLine(ex.Source);
    //Console.WriteLine(ex.StackTrace);
    Console.WriteLine(ex);
}

/*
static void SortPeople(List<Person> people)
{
    for (int i = 0; i < people.Count; i++)
    {
        for (int j = i + 1; j < people.Count; j++)
        {
            if (people[i].CompareTo(people[j]) > 0)
            {
                Person temp = people[i];
                people[i] = people[j];
                people[j] = temp;
            }
        }
    }
}
*/
/*
static void SortPeople(List<Person> people)
{
    PersonComparer personComparer = new();
    for (int i = 0; i < people.Count; i++)
    {
        for (int j = i + 1; j < people.Count; j++)
        {
            if (personComparer.Compare(people[i], people[j]) > 0)
            {
                Person temp = people[i];
                people[i] = people[j];
                people[j] = temp;
            }
        }
    }
}
*/