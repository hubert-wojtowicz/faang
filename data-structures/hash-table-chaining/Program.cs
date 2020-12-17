using System;
using System.Collections.Generic;
using System.Linq;

namespace hash_table_chaining
{
    class Program
    {
        static void Main(string[] args)
        {
            var ht = new EmployeeHashTable(10);

            ht.Insert(new Employee { FullName = "A", Phone = "10001" });
            ht.Insert(new Employee { FullName = "B", Phone = "10002" });
            ht.Insert(new Employee { FullName = "C", Phone = "10003" });
            ht.Insert(new Employee { FullName = "AA", Phone = "100011" });
            ht.Insert(new Employee { FullName = "AB", Phone = "100021" });

            bool cont = ht.Contains(new Employee { FullName = "AA", Phone = "100011" });

            Console.ReadKey();
        }
    }

    public class EmployeeHashTable
    {
        private readonly int _size;
        public List<Employee>[] _table;

        public EmployeeHashTable(int size)
        {
            _size = size;
            _table = new List<Employee>[size];
        }

        public void Insert(Employee elem)
        {
            var index = elem.GetHashCode() % _size;
            _table[index] = _table[index] ?? new List<Employee>();
            _table[index].Add(elem);
        }

        public void Delete(Employee elem)
        {
            var items = _table[GetHashCode() % _size];
            if (items == null)
                return;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(elem))
                {
                    items.RemoveAt(i);
                    return;
                }
            }
        }

        public bool Contains(Employee elem)
        {
            var items = _table[elem.GetHashCode() % _size];
            if (items == null)
                return false;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Equals(elem))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Employee
    {
        public string Phone { get; set; }
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            Employee other = obj as Employee;
            return other != null
                && FullName.Trim().Equals(other.FullName.Trim())
                && Phone.Trim().Equals(other.Phone.Trim());
        }

        public override int GetHashCode()
        {
            return int.Parse(Phone.Trim().Substring(Phone.Length - 3, 3).TrimStart('0'));
        }
    }
}
