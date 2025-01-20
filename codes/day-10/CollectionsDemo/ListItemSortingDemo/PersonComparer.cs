using PeronLibrary;

namespace ListItemSortingDemo
{
    internal class PersonComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (x == null && y == null)
                throw new ArgumentNullException($"{nameof(x)}, {nameof(y)} are null");
            if (x == null || y == null) throw new ArgumentNullException($"either {nameof(x)} or {nameof(y)} is null");

            if (x == y) return 0;

            if (x.Id.CompareTo(y.Id) == 0)
                if (x.Name.CompareTo(y.Name) == 0)
                    return x.Salary.CompareTo(y.Salary);
                else
                    return x.Name.CompareTo(y.Name);
            else
                return x.Id.CompareTo(y.Id);
        }
    }
}
