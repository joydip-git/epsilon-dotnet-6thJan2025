using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQApp
{
    class Department
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public List<Person>? People { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}
