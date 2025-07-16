using ITI_Smart_University_Management_System_Day7.University_System;

namespace SmartUniversity
{
    internal static class UniversityStats
    {
        static UniversityStats() { }

        public static void PrintStudentCount()
        {
            Console.WriteLine($"Total Students: {Student.TotalStudents}");
        }
    }
}
