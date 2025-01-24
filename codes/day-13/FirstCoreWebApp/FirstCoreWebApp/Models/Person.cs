namespace FirstCoreWebApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Salary={Salary}";
        }
    }
}
