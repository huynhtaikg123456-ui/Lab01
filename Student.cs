using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Student : Person
    {
        private float averageScore;
        private string faculty;
        public Student() { }
        public Student(string id, string fullName, float averageScore, string faculty)
            : base(id, fullName)
        {
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public override void Input()
        {
            base.Input();
            Console.Write($"Nhập Khoa: ");
            Faculty = Console.ReadLine();
            Console.Write($"Nhập Điểm trung bình: ");
            AverageScore = float.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine("Điểm trung bình: {0} - Khoa: {1}", this.AverageScore, this.Faculty);
        }
    }
}
