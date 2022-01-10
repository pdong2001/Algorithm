using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public class SortedList<T> : List<T>
    {
        public List<IIndex<T>> Indices;

        public SortedList(List<IIndex<T>> indices)
        {
            Indices = new(indices);
        }

        public SortedList(IIndex<T> key)
        {
            Indices = new();
            Indices.Add(key);
        }

        public new void Add(T value)
        {
            int minNum = 0;
            int maxNum = Count - 1;
            var comparer = new IndexCompare<T>(Indices);

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (comparer.Compare(value, this[mid]) == 0)
                {
                    base.Insert(mid, value);
                    return;
                }
                else if (comparer.Compare(value, this[mid]) < 0)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            base.Insert(minNum, value);
        }

        public new int IndexOf(T value)
        {
            int minNum = 0;
            int maxNum = Count - 1;
            var comparer = new IndexCompare<T>(Indices);

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (comparer.Compare(value, this[mid]) == 0)
                {
                    return mid;
                }
                else if (comparer.Compare(value, this[mid]) < 0)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return -1;
        }
    }

    public class Index<T, TCol> : IIndex<T>
        where TCol : IComparable
    {
        public int Order { get; set; }
        public Func<T, TCol> Column { get; private set; }

        public Index(Func<T, TCol> Column, int Order)
        {
            this.Column = Column;
            this.Order = Order;
        }

        public void SetColumn(Func<T, TCol> selector)
        {
            Column = selector;
        }

        public string GetColumnName()
        {
            return nameof(TCol);
        }

        public int Compare(T? x, T? y)
        {
            return Column(x).CompareTo(Column(y));
        }
    }
    public interface IIndex<T>
    {
        public int Order { get; set; }

        public string GetColumnName();

        public int Compare(T? x, T? y);
    }


    public class IndexCompare<T> : IComparer<T>
    {
        private readonly List<IIndex<T>> Indices;

        public IndexCompare(List<IIndex<T>> indices)
        {
            Indices = new(indices);
            Indices.OrderByDescending(i => i.Order);
        }

        public int Compare(T? x, T? y)
        {
            foreach (var index in Indices)
            {
                var compare = index.Compare(x, y);
                if (compare != 0)
                {
                    return compare;
                }
            }
            return 0;
        }
    }

    public struct Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public Person(int Id, string Name)
        {
            Random rd = new Random();
            this.Id = Id;
            this.Name = Name;
            this.Birth = DateTime.Now.AddDays(rd.Next(-100000, -50000));
        }
        public override string ToString()
        {
            return $"{Id.ToString().PadLeft(3, '0')} : {Name} - {Birth}";
        }
    }
    public static class Test
    {
        public static void TestList(int n)
        {
            Random rd = new Random();
            SortedList<int> table = new(new Index<int, int>(i => i, 1));
            table.Capacity = n;
            List<int> list = new List<int>(n);
            List<IIndex<Person>> personIndices = new();
            personIndices.Add(new Index<Person, int>(i => i.Id, 1));
            personIndices.Add(new Index<Person, string>(i => i.Name, 2));
            personIndices.Add(new Index<Person, DateTime>(i => i.Birth, 3));
            SortedList<Person> tablePerson = new(personIndices);
            //Common.Monitoring(() =>
            //{
            //    for (int i = 0; i < n; i++)
            //    {
            //        table.Add(rd.Next(-n, n));
            //    }
            //    Console.WriteLine(table.ToArray().IsSorted());
            //});
            //Common.Monitoring(() =>
            //{
            //    list.Add(rd.Next(-n, n));
            //    for (int i = 0; i < n - 1; i++)
            //    {
            //        bool Added = false;
            //        var value = rd.Next(-n, n);
            //        for (int j = 0; j < i+1; j++)
            //        {
            //            if (list[j] > value)
            //            {
            //                list.Insert(j, value);
            //                Added = true;
            //                break;
            //            }
            //        }
            //        if (!Added)
            //        {
            //            list.Add(value);
            //        }
            //    }
            //    Console.WriteLine(list.ToArray().IsSorted());
            //});
            Common.Monitoring(() =>
            {
                for (int i = n; i >= 0; i--)
                {
                    tablePerson.Add(new Person(i + 1, "Người"));
                }
                tablePerson.ForEach(p => Console.WriteLine(p));
            });
        }
    }

}
