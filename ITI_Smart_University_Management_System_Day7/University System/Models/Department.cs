using ITI_Smart_University_Management_System_Day7.University_System.Base;

namespace ITI_Smart_University_Management_System_Day7.University_System.Sections
{
    internal class Department
    {
        public string Name { get; set; }
        public DepartmentType Type { get; set; }

        private Course[] Courses;
        private Instructor[] Instructors;
        private int coursescount = 0;
        private int instructorcount = 0;

        public Department(string name, DepartmentType type, int maxCourses = 10, int maxInstructors = 5)
        {
            Name = name;
            Type = type;
            Courses = new Course[maxCourses];
            Instructors = new Instructor[maxInstructors];
        }

        public void AddCourse(Course course)
        {
            if (coursescount >= Courses.Length)
            {
                Console.WriteLine("Error, Courses in this department are full!");
                return;
            }
            Courses[coursescount] = course;
            coursescount++;
            Console.WriteLine($"Course {course.Title} added to {Name} successfully!");

        }

        public void AddInstructor(Instructor instructor)
        {
            if (instructorcount >= Instructors.Length)
            {
                Console.WriteLine($"Error: Cannot add more instructors to {Name} Department.");
                return;
            }

            Instructors[instructorcount++] = instructor;
            Console.WriteLine($"Instructor '{instructor.Name}' added to {Name} Department.");
        }

        public Course[] GetCourses() => Courses;

        public Instructor[] GetInstructors() => Instructors;
    }
}

