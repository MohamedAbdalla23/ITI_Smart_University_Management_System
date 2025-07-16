using ITI_Smart_University_Management_System_Day7.University_System.Base;

namespace ITI_Smart_University_Management_System_Day7.University_System
{
    internal class Student : Person, IEvaluable
    {
        private double gpa;
        private static int totalstudent;

        public double GPA
        {
            get { return gpa; }
            set
            {
                if (value < 0.0 || value > 4.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(GPA), "GPA must be between 0.0 and 4.0");
                }
                gpa = value;
            }
        }

        public GradeLevel GradeLevel { get; set; }

        public static int TotalStudents => totalstudent;

        public Student() : base()
        {
            totalstudent++;
        }

        public Student(string name, string email, string phone, Address address, double gpa, GradeLevel gradeLevel)
            : this()
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            GPA = gpa;
            GradeLevel = gradeLevel;
        }

        public override void DisplayProfile()
        {
            Console.WriteLine($"Student's Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"GPA: {GPA}");
            Console.WriteLine($"Grade Level: {GradeLevel}");
            Console.WriteLine($"Address: {Address.Street}, {Address.City}, {Address.PostalCode}");
        }

        public void EvaluatePerformance()
        {
            Console.WriteLine($"Evaluating student {Name}'s GPA: {GPA}");
        }
    }

}
