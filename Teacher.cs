using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Teacher : Person
    {
        private string address;
        public Teacher() { }
        public Teacher(string id, string fullname, string address)
            : base(id, fullname)
        {
            this.Address = address;
        }
        public string Address { get => address; set => address = value; }
        public override void Input()
        {
            base.Input();
            Console.Write($"Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine("Địa chỉ: {0}", this.Address);
        }
    }
}

