using ITI_Smart_University_Management_System_Day7.University_System.Base;

namespace ITI_Smart_University_Management_System_Day7.University_System
{
    internal class Instructor : Person, IEvaluable
    {
        public DepartmentType Department { get; set; }

        public Instructor()
        {

        }

        public Instructor(string name, string email, string phone, Address address, DepartmentType department)
            : base(name, email, phone, address)
        {
            Department = department;
        }

        public override void DisplayProfile()
        {
            Console.WriteLine($"Instructor's Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Address: {Address.Street}, {Address.City}, {Address.PostalCode}");
        }

        public void EvaluatePerformance()
        {
            Console.WriteLine($"Instructor {Name} is being evaluated for performance in {Department} Department.");
        }
    }
}

