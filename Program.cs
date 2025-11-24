using Lab01_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Xuất ra thông tin của các SV đều thuộc khoa “CNTT”");
                Console.WriteLine("4. Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5.");
                Console.WriteLine("5. Xuất ra danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần");
                Console.WriteLine("6. Xuất ra danh sách sinh viên có điểm TB lớn hơn bằng 5 và thuộc khoa “CNTT”");
                Console.WriteLine("7. Xuất ra danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa “CNTT”");
                Console.WriteLine("8. Hãy cho biết số lượng của từng xếp loại trong danh sách?");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);

                        break;
                    case "2":
                        DisplayStudentList(studentList);

                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        DisplayStudentClassificationCount(studentList);
                        break;
                    case "0":
                        exit = true;

                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0}", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty,
            StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList,
   float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0}", minDTB);
            var students = studentList.Where(s => s.AverageScore >= minDTB).ToList();
            DisplayStudentList(students);
        }
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần === ");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sortedStudents);
        }
        //case 7: Xuất ra danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa “CNTT” (using query syntax)
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa {0}", faculty);
            var query = from s in studentList
                        where s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)
                        let maxScore = (from st in studentList
                                        where st.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)
                                        select st.AverageScore).Max()
                        where s.AverageScore == maxScore
                        select s;
            DisplayStudentList(query.ToList());
        }
        //case 8: Số lượng từng xếp loại (using method syntax, as GroupBy is not directly supported in query syntax)
        static void DisplayStudentClassificationCount(List<Student> studentList)
        {
            Console.WriteLine("=== Số lượng sinh viên theo xếp loại ===");
            var classifications = studentList.GroupBy(s => GetClassification(s.AverageScore))
                                             .Select(g => new { Classification = g.Key, Count = g.Count() })
                                             .OrderBy(c => c.Classification); // Optional: order by classification
            foreach (var item in classifications)
            {
                Console.WriteLine("{0}: {1}", item.Classification, item.Count);
            }
        }
        // Helper method to get classification based on score
        static string GetClassification(float score)
        {
            if (score >= 9.0f && score <= 10.0f) return "Xuất sắc";
            if (score >= 8.0f && score < 9.0f) return "Giỏi";
            if (score >= 7.0f && score < 8.0f) return "Khá";
            if (score >= 5.0f && score < 7.0f) return "Trung bình";
            if (score >= 4.0f && score < 5.0f) return "Yếu";
            return "Kém";
        }
    }
}


