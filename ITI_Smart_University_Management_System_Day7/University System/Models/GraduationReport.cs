using ITI_Smart_University_Management_System_Day7.University_System;

namespace SmartUniversity
{
    internal sealed class GraduationReport
    {
        private readonly Student[] students;

        public GraduationReport(Student[] students)
        {
            this.students = students;
        }

        public void Print()
        {
            Console.WriteLine("\n=== Graduation Report ===");
            foreach (var s in students)
            {
                if (s != null)
                {
                    s.DisplayProfile();
                    s.EvaluatePerformance();
                }
            }
        }
    }
}