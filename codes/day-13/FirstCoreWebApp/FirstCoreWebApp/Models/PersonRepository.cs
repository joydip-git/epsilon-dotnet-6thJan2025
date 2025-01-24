namespace FirstCoreWebApp.Models
{
    public static class PersonRepository
    {
        public static List<Person> People { get; } =
        [
            new (){ Id=1, Name="joydip", Salary=3000},
            new (){ Id=3, Name="anil", Salary=2000},
            new (){ Id=2, Name="sunil", Salary=1000},
        ];

    }
}
