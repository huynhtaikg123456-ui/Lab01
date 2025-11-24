using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách (tổng số sinh viên, tổng số giáo viên)");
                Console.WriteLine("6. Xuất danh sách các Sinh Viên thuộc khoa “CNTT”");
                Console.WriteLine("7. Xuất ra danh sách giáo viên có địa chỉ chứa thông tin “Quận 9”");
                Console.WriteLine("8. Xuất ra danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa “CNTT”");
                Console.WriteLine("9. Hãy cho biết số lượng của từng xếp loại trong danh sách?");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-9): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        AddTeacher(teacherList);
                        break;
                    case "3":
                        DisplayStudentList(studentList);
                        break;
                    case "4":
                        DisplayTeacherList(teacherList);
                        break;
                    case "5":
                        DisplayCounts(studentList, teacherList);
                        break;
                    case "6":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "7":
                        DisplayTeachersByAddress(teacherList, "Quận 9");
                        break;
                    case "8":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "9":
                        DisplayStudentClassificationCount(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                        Console.WriteLine();
                }
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

        static void AddTeacher(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Nhập thông tin giáo viên ===");
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
            foreach (Student student in studentList)
            {
                student.Output();
            }
        }

        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin giáo viên ===");
            foreach (Teacher teacher in teacherList)
            {
                teacher.Output();
            }
        }

        static void DisplayCounts(List<Student> studentList, List<Teacher> teacherList)
        {
            Console.WriteLine("=== Số lượng ===");
            Console.WriteLine("Tổng số sinh viên: {0}", studentList.Count);
            Console.WriteLine("Tổng số giáo viên: {0}", teacherList.Count);
        }

        //6. Xuất danh sách các Sinh Viên thuộc khoa “CNTT” (using query syntax)
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0}", faculty);
            var query = from s in studentList
                        where s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)
                        select s;
            DisplayStudentList(query.ToList());
        }

        //7. Xuất ra danh sách giáo viên có địa chỉ chứa thông tin “Quận 9” (using query syntax)
        static void DisplayTeachersByAddress(List<Teacher> teacherList, string addressPart)
        {
            Console.WriteLine("=== Danh sách giáo viên có địa chỉ chứa \"{0}\"", addressPart);
            var query = from t in teacherList
                        where t.Address.Contains(addressPart)
                        select t;
            DisplayTeacherList(query.ToList());
        }

        //8. Xuất ra danh sách sinh viên có điểm trung bình cao nhất và thuộc khoa “CNTT” (using query syntax)
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

        //9. Số lượng từng xếp loại (using method syntax)
        static void DisplayStudentClassificationCount(List<Student> studentList)
        {
            Console.WriteLine("=== Số lượng sinh viên theo xếp loại ===");
            var classifications = studentList.GroupBy(s => GetClassification(s.AverageScore))
                                             .Select(g => new { Classification = g.Key, Count = g.Count() })
                                             .OrderBy(c => c.Classification);
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
