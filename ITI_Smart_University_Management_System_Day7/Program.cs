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

            bool running = true;

            while (running)
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

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Department Name: ");
                        string dName = Console.ReadLine()!;
                        Console.WriteLine("Department Type: IT, HR, Business, Engineering");
                        DepartmentType dType = Enum.Parse<DepartmentType>(Console.ReadLine()!, true);

                        Department newDept = new Department(dName, dType);
                        university.AddDepartment(newDept);
                        allDepartments[departmentCount++] = newDept;

                        Console.WriteLine("Department added successfully.");
                        break;

                    case "2":
                        Console.Write("Student Name: ");
                        string sName = Console.ReadLine()!;
                        Console.Write("Email: ");
                        string sEmail = Console.ReadLine()!;
                        Console.Write("Phone: ");
                        string sPhone = Console.ReadLine()!;
                        Console.Write("Street: ");
                        string sStreet = Console.ReadLine()!;
                        Console.Write("City: ");
                        string sCity = Console.ReadLine()!;
                        Console.Write("Postal Code: ");
                        int sPostal = int.Parse(Console.ReadLine()!);
                        Address sAddress = new Address
                        {
                            Street = sStreet,
                            City = sCity,
                            PostalCode = sPostal
                        };
                        Console.Write("GPA (0.0 - 4.0): ");
                        double sGPA = double.Parse(Console.ReadLine()!);

                        Console.WriteLine("Grade Level: Freshman, Sophomore, Junior, Senior");
                        GradeLevel sLevel = Enum.Parse<GradeLevel>(Console.ReadLine()!, true);

                        try
                        {
                            Student student = new Student(sName, sEmail, sPhone, sAddress, sGPA, sLevel);
                            allStudents[studentCount++] = student;
                            Console.WriteLine("Student added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "3":
                        Console.Write("Instructor Name: ");
                        string iName = Console.ReadLine()!;
                        Console.Write("Email: ");
                        string iEmail = Console.ReadLine()!;
                        Console.Write("Phone: ");
                        string iPhone = Console.ReadLine()!;
                        Console.Write("Street: ");
                        string iStreet = Console.ReadLine()!;
                        Console.Write("City: ");
                        string iCity = Console.ReadLine()!;
                        Console.Write("Postal Code: ");
                        int iPostal = int.Parse(Console.ReadLine()!);
                        Address iAddress = new Address
                        {
                            Street = iStreet,
                            City = iCity,
                            PostalCode = iPostal
                        };

                        Console.WriteLine("Department Type: IT, HR, Business, Engineering");
                        DepartmentType iDept = Enum.Parse<DepartmentType>(Console.ReadLine()!, true);

                        Instructor instructor = new Instructor(iName, iEmail, iPhone, iAddress, iDept);

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

                        break;

                    case "4":
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
                            break;
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
                                break;
                            }
                        }

                        if (courseDept == null)
                        {
                            Console.WriteLine("Department not found. Please add it first.");
                            break;
                        }

                        Course course = new Course { Title = courseTitle };
                        courseDept.AddCourse(course);

                        try
                        {
                            Course.Enroll(foundStudent);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;

                    case "5":
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
                            break;
                        }

                        Console.WriteLine($"\nDepartment: {reportDept.Name} ({reportDept.Type})");
                        Console.WriteLine("Courses:");
                        foreach (var c in reportDept.GetCourses())
                        {
                            if (c != null)
                                Console.WriteLine($"- {c.Title}");
                        }
                        Console.WriteLine("Instructors:");
                        foreach (var i in reportDept.GetInstructors())
                        {
                            if (i != null)
                                Console.WriteLine($"- {i.Name}");
                        }
                        break;

                    case "6":
                        UniversityStats.PrintStudentCount();
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
