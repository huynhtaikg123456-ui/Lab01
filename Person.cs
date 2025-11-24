using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Person
    {
        // Fields
        private string id;
        private string name;
        // Properties
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        // Constructor
        public Person()
        {
        }
        public Person(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
        // Methods
        public virtual void Input()
        {
            Console.Write("Nhập Mã số:");
            Id = Console.ReadLine();
            Console.Write("Nhập Họ tên:");
            Name = Console.ReadLine();
        }
        public virtual void Output()
        {
            Console.WriteLine("Mã số:{0} Họ Tên:{1}", this.Id, this.Name);
        }
    }
}

