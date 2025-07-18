using ITI_Smart_University_Management_System_Day7.University_System;
using ITI_Smart_University_Management_System_Day7.University_System.Base;
using ITI_Smart_University_Management_System_Day7.University_System.Sections;

namespace SmartUniversity
{
    class Program
    {
        static void Main(string[] args)
        {
            University university = new University("Smart University");
            Student[] allStudents = new Student[100];
            Department[] allDepartments = new Department[10];
            int departmentCount = 0;
            int studentCount = 0;
            int choice;

            while (true)
            {
                Console.WriteLine("\n===== SMART UNIVERSITY MANAGEMENT MENU =====");                    
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Assign Instructor");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. View Department Report");
                Console.WriteLine("6. Show University Statistics");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                try
                {                                                                    //Handle Null inputs(other than numbers)
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        throw new ArgumentNullException();

                    choice = int.Parse(input);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    continue; 
                }

                switch (choice)
                {
                    case 1:
                        AddDepartment(ref departmentCount, allDepartments, university);
                        break;
                    case 2:
                        AddStudent(ref studentCount, allStudents);
                        break;
                    case 3:
                        AssignInstructor(allDepartments);
                        break;
                    case 4:
                        EnrollStudentInCourse(allStudents, allDepartments, studentCount);
                        break;
                    case 5:
                        ViewDepartmentReport(allDepartments);
                        break;
                    case 6:
                        UniversityStats.PrintStudentCount();
                        break;
                    case 7:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        //Case 1
        public static void AddDepartment(ref int departmentCount, Department[] allDepartments, University university)
        {
            Console.Write("Department Name: ");
            string departmentname = Console.ReadLine()!;
            Console.WriteLine("Department Type: IT, HR, Business, Engineering");
            DepartmentType departmenttype = Enum.Parse<DepartmentType>(Console.ReadLine()!, true);

            Department newDept = new Department(departmentname, departmenttype);
            university.AddDepartment(newDept);
            allDepartments[departmentCount++] = newDept;

            Console.WriteLine("Department added successfully.");
        }


        //Case 2
        public static void AddStudent(ref int studentCount, Student[] allStudents)
        {
            Console.Write("Student Name: ");
            string studentname = Console.ReadLine()!;
            Console.Write("Email: ");
            string studentemail = Console.ReadLine()!;
            Console.Write("Phone: ");
            string studentphone = Console.ReadLine()!;
            Console.Write("Street: ");
            string studentstreet = Console.ReadLine()!;
            Console.Write("City: ");
            string studentcity = Console.ReadLine()!;
            Console.Write("Postal Code: ");
            int studentpostal = int.Parse(Console.ReadLine()!);
            Address studentaddress = new()
            {
                Street = studentstreet,
                City = studentcity,
                PostalCode = studentpostal
            };
            Console.Write("GPA (0.0 - 4.0): ");
            double studentgpa = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Grade Level: Freshman, Sophomore, Junior, Senior");
            GradeLevel studentlvl = Enum.Parse<GradeLevel>(Console.ReadLine()!, true);

            try
            {
                Student student = new Student(studentname, studentemail, studentphone, studentaddress, studentgpa, studentlvl);
                allStudents[studentCount++] = student;
                Console.WriteLine("Student added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        //Case 3
        public static void AssignInstructor(Department[] allDepartments)
        {
            Console.Write("Instructor Name: ");
            string instructorname = Console.ReadLine()!;
            Console.Write("Email: ");
            string instructoremail = Console.ReadLine()!;
            Console.Write("Phone: ");
            string instructorphone = Console.ReadLine()!;
            Console.Write("Street: ");
            string instructorstreet = Console.ReadLine()!;
            Console.Write("City: ");
            string instructorcity = Console.ReadLine()!;
            Console.Write("Postal Code: ");
            int instructorpostal = int.Parse(Console.ReadLine()!);
            Address instructoraddress = new()
            {
                Street = instructorstreet,
                City = instructorcity,
                PostalCode = instructorpostal
            };

            Console.WriteLine("Department Type: IT, HR, Business, Engineering");
            DepartmentType instreuctordepartment = Enum.Parse<DepartmentType>(Console.ReadLine()!, true);

            Instructor instructor = new(instructorname, instructoremail, instructorphone, instructoraddress, instreuctordepartment);

            Console.Write("Department Name to assign: ");
            string deptName = Console.ReadLine()!;

            Department? deptForInstructor = null;
            foreach (var dept in allDepartments)
            {
                if (dept != null && dept.Name.Equals(deptName, StringComparison.OrdinalIgnoreCase))
                {
                    deptForInstructor = dept;
                    break;
                }
            }

            if (deptForInstructor != null)
            {
                deptForInstructor.AddInstructor(instructor);
                Console.WriteLine("Instructor assigned successfully.");
            }
            else
            {
                Console.WriteLine("Department not found. Please add it first.");
            }
        }


        //Case 4
        public static void EnrollStudentInCourse(Student[] allStudents, Department[] allDepartments, int studentCount)
        {
            Console.Write("Student Name: ");
            string eName = Console.ReadLine()!;
            Student? foundStudent = null;
            for (int i = 0; i < studentCount; i++)
            {
                if (allStudents[i].Name.Equals(eName, StringComparison.OrdinalIgnoreCase))
                {
                    foundStudent = allStudents[i];
                    break;
                }
            }

            if (foundStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Course Title: ");
            string courseTitle = Console.ReadLine()!;
            Console.Write("Department Name for Course: ");
            string courseDeptName = Console.ReadLine()!;

            Department? courseDept = null;
            foreach (var dept in allDepartments)
            {
                if (dept != null && dept.Name.Equals(courseDeptName, StringComparison.OrdinalIgnoreCase))
                {
                    courseDept = dept;
                }
            }

            if (courseDept == null)
            {
                Console.WriteLine("Department not found. Please add it first.");
                return;
            }

            Course course = new() { Title = courseTitle };
            courseDept.AddCourse(course);

            try
            {
                Course.Enroll(foundStudent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        //Case 5
        public static void ViewDepartmentReport(Department[] allDepartments)
        {
            Console.Write("Department Name: ");
            string reportDeptName = Console.ReadLine()!;
            Department? reportDept = null;

            foreach (var dept in allDepartments)
            {
                if (dept != null && dept.Name.Equals(reportDeptName, StringComparison.OrdinalIgnoreCase))
                {
                    reportDept = dept;
                    break;
                }
            }

            if (reportDept == null)
            {
                Console.WriteLine("Department not found.");
                return;
            }

            Console.WriteLine($"\nDepartment: {reportDept.Name} ({reportDept.Type})");
            Console.WriteLine("Courses:");
            foreach (var c in reportDept.GetCourses())
            {
                if (c != null) Console.WriteLine($"- {c.Title}");
            }
            Console.WriteLine("Instructors:");
            foreach (var i in reportDept.GetInstructors())
            {
                if (i != null) Console.WriteLine($"- {i.Name}");
            }
        }
    }
}
