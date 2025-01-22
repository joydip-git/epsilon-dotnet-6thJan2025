using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQApp
{
    class Person
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public decimal Salary { get; set; } = 0;
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Salary}";
        }
    }
}
