namespace LINQApp
{
    internal class Program
    {
        static void Main()
        {
            List<Person> people =
                [
                    new Person{ Id=1, Name="sunil", Salary = 1000},
                    new Person{ Id=3, Name="joydip", Salary = 3000},
                    new Person{ Id=2, Name="anil", Salary = 2000},
                    new Person{ Id=4, Name="sooraj", Salary = 1500},
                ];

            List<Department> departments =
                [
                new Department{Id=1, Name="HR", People=[people[1],people[2]]},
                new Department{Id=2, Name="Training", People=[people[0], people[3]]},
                new Department{Id=3, Name ="Security", People=[]}
                ];

            people[0].Department = departments[1];
            people[3].Department = departments[1];

            people[1].Department = departments[0];
            people[2].Department = departments[0];

            //IEnumerable<Person> filteredPeople = people.Where(p => p.Name.ToLower().Contains('n'));
            //IOrderedEnumerable<Person> orderedPeople = filteredPeople.OrderByDescending(p => p.Salary);
            //List<Person> finalList = orderedPeople.ToList();
            //finalList.ForEach(p => Console.WriteLine(p));


            //Method query
            //Deferred Execution
            //var finalResult = people
            //    .Where(p => p.Salary >= 2000)
            //    .OrderByDescending(p => p.Salary);

            //Immediate Execution
            var finalResult = people
               .Where(p => p.Salary >= 2000)
               .OrderByDescending(p => p.Salary)
               .ToList();

            // Query operator [gets converted to method query syntax anyway]
            // p => range variable
            // where and orderby and select (clauses) operators
            //Deferred Execution
            //var result = from p in people
            //             where p.Salary >= 2000
            //             orderby p.Salary descending
            //             select p;

            //Immediate Execution
            var result = (from p in people
                          where p.Salary >= 2000
                          orderby p.Salary descending
                          select p).ToList();


            //producing the result set from Method query
            //finalResult.ToList();

            //displaying the results from the result set of Method Query
            //finalResult.ToList().ForEach(p =>Console.WriteLine(p));
            finalResult.ForEach(p => Console.WriteLine(p));

            //displaying the results from the result set of Query operator
            foreach (var p in result)
                Console.WriteLine(p);

            var salaryStatistics = new
            {
                Maximum = people.Max(p => p.Salary),
                Minimum = people.Min(p => p.Salary),
                Average = people.Average(p => p.Salary)
            };
            Console.WriteLine($"Max: {salaryStatistics.Maximum}, Min: {salaryStatistics.Minimum}, Avg: {salaryStatistics.Average}");


            //IEnumerable<IGrouping<char, Person>> peopleGroupQuery =
            //    from p in people
            //    orderby p.Name ascending
            //    group p by p.Name[0];

            IEnumerable<IGrouping<char, Person>> peopleGroupQuery =
               people
               .OrderBy(p => p.Name)
               .GroupBy(p => p.Name[0]);

            //group => key(char) and collection (person objects)
            foreach (var group in peopleGroupQuery)
            {
                Console.WriteLine(group.Key + "\n____________________");
                foreach (var person in group)
                {
                    Console.WriteLine(person.Name);
                }
                Console.WriteLine("\n");
            }

            //var joinQuery = from p in people
            //                join d in departments
            //                on p.Department?.Id equals d.Id
            //                select new { PersonName = p.Name, Department = d.Name };
            var joinQuery = people
                .Join(
                    departments,
                    p => p.Department?.Id,
                    d => d.Id,
                    (p, d) => new
                    {
                        PersonName = p.Name,
                        Department = d.Name
                    }
                );

            joinQuery
                .ToList()
                .ForEach(pd => Console.WriteLine($"{pd.PersonName} => {pd.Department}"));

            Console.WriteLine("\npeople by dept\n");
            var leftOuterGroupJoinQuery =
                from d in departments
                join p in people
                on d.Id equals p.Department?.Id into g
                orderby d.Name
                select new
                {
                    Dept = d.Name,
                    PersonList =
                    from person in g.DefaultIfEmpty(new Person { Id = 0, Name = "NA" })
                    orderby person.Name
                    select person
                };

            foreach (var group in leftOuterGroupJoinQuery)
            {
                Console.WriteLine($"Department: {group.Dept}");
                Console.WriteLine("----------------");
                foreach (var person in group.PersonList)
                {
                    Console.WriteLine(person.Name);
                }
                Console.WriteLine("\n");
            }

            //UseExtensionMethodsAndDelegates(people);
        }

        private static void UseExtensionMethodsAndDelegates(IEnumerable<Person> people)
        {
            Console.WriteLine("1. Sort by id");
            Console.WriteLine("2. Sort by name");
            Console.WriteLine("3. Sort by salary");

            Console.Write("enter choice[1/2/3]: ");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            Console.WriteLine("a. in ascending order");
            Console.WriteLine("b. in descending order");

            Console.Write("enter order[a/b]: ");
            char order = char.Parse(Console.ReadLine() ?? "a");

            /*
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    int? comparisonResult = null;
                    switch (choice)
                    {
                        case 1:
                            comparisonResult = people[i].Id.CompareTo(people[j].Id);
                            break;

                        case 2:
                            comparisonResult = people[i].Name.CompareTo(people[j].Name);
                            break;

                        case 3:
                            comparisonResult = people[i].Salary.CompareTo(people[j].Salary);
                            break;

                        default:
                            comparisonResult = people[i].Id.CompareTo(people[j].Id);
                            break;
                    }

                    if (comparisonResult.HasValue)
                    {
                        if (comparisonResult.Value > 0)
                        {
                            Person? temp = null;
                            switch (order)
                            {
                                case 'a':
                                    temp = people[i];
                                    people[i] = people[j];
                                    people[j] = temp;
                                    break;

                                case 'b':
                                    temp = people[j];
                                    people[j] = people[i];
                                    people[i] = temp;
                                    break;

                                default:
                                    temp = people[i];
                                    people[i] = people[j];
                                    people[j] = temp;
                                    break;
                            }

                        }
                    }
                }
            }
            */

            //Comparison delegate:
            //delegate int Comparison<in T>(T x, T y);

            //Comparison<Person>? comparison = null;
            //comparison = choice switch
            //{
            //    1 => (p1, p2) => p1.Id.CompareTo(p2.Id),
            //    2 => (p1, p2) => p1.Name.CompareTo(p2.Name),
            //    3 => (p1, p2) => p1.Salary.CompareTo(p2.Salary),
            //    _ => (p1, p2) => p1.Id.CompareTo(p2.Id),
            //};
            //people.Sort(comparison);

            //Func delegate (version-2):
            //delegate TResult Func<in T, out TResult>(T arg);

            IOrderedEnumerable<Person>? result;
            switch (order)
            {
                case 'a':
                    result = SortInAscendingOrder(choice, people);
                    break;

                case 'b':
                    result = SortInDescendingOrder(choice, people);
                    break;

                default:
                    result = null;
                    break;
            }
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("1. filter by name");
            Console.WriteLine("2. filter by salary");

            Console.Write("enter choice[1/2]: ");
            int filterChoice = int.Parse(Console.ReadLine() ?? "1");

            var filteredPeople = FilterPeople(filterChoice, people);
            filteredPeople.ToList().ForEach(p => Console.WriteLine(p));
        }

        private static IEnumerable<Person> FilterPeople(int filterChoice, IEnumerable<Person> people)
        {
            string? filterText = null;
            if (filterChoice == 1)
            {
                Console.Write("filter by[enter partial or fullname]: ");
                filterText = Console.ReadLine() ?? "";
            }
            Func<Person, bool>? filterByName = null;
            if (filterText != string.Empty && filterText != null)
                filterByName = p => p.Name.ToLower().Contains<char>('n');
            Func<Person, bool> filterBySalary = p => p.Salary >= 2000;

            var result = filterChoice switch
            {
                1 => people.Where(filterByName),
                2 => people.Where(filterBySalary),
                _ => people.Where(filterByName),
            };
            return result;
        }

        private static IOrderedEnumerable<Person>? SortInDescendingOrder(int choice, IEnumerable<Person> people)
        {
            Func<Person, int> sortById = p => p.Id;
            Func<Person, string> sortByName = p => p.Name;
            Func<Person, decimal> sortBySalary = p => p.Salary;

            var result = choice switch
            {
                //1 => people.OrderBy(p => p.Id),
                1 => people.OrderByDescending(sortById),
                //2 => people.OrderBy(p => p.Name),
                2 => people.OrderByDescending(sortByName),
                //3 => people.OrderBy(p => p.Salary),
                3 => people.OrderByDescending(sortBySalary),
                //_ => people.OrderBy(p => p.Id),
                _ => people.OrderByDescending(sortById),
            };
            return result;
        }

        static IOrderedEnumerable<Person> SortInAscendingOrder(int choice, IEnumerable<Person> people)
        {
            Func<Person, int> sortById = p => p.Id;
            Func<Person, string> sortByName = p => p.Name;
            Func<Person, decimal> sortBySalary = p => p.Salary;

            var result = choice switch
            {
                //1 => people.OrderBy(p => p.Id),
                1 => people.OrderBy(sortById),
                //2 => people.OrderBy(p => p.Name),
                2 => people.OrderBy(sortByName),
                //3 => people.OrderBy(p => p.Salary),
                3 => people.OrderBy(sortBySalary),
                //_ => people.OrderBy(p => p.Id),
                _ => people.OrderBy(sortById),
            };
            return result;
        }
    }
}
