using ITI_Smart_University_Management_System_Day7.University_System.Sections;

namespace ITI_Smart_University_Management_System_Day7.University_System
{
    internal class University
    {
        private Department[] departments;
        private int departmentCount = 0;

        public string Name { get; set; }

        public University(string name, int maxDepartments = 5)
        {
            Name = name;
            departments = new Department[maxDepartments];
        }

        public void AddDepartment(Department department)
        {
            if (departmentCount >= departments.Length)
            {
                Console.WriteLine("Error: Cannot add more departments.");
                return;
            }
            departments[departmentCount++] = department;
            Console.WriteLine($"Department '{department.Name}' added to University '{Name}'.");
        }

        public void ViewAllDepartments()
        {
            Console.WriteLine($"\n--- University: {Name} Departments ---");
            for (int i = 0; i < departmentCount; i++)
            {
                Console.WriteLine($"  - {departments[i].Name} ({departments[i].Type})");
            }
        }
    }
}
