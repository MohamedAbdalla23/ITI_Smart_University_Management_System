namespace ITI_Smart_University_Management_System_Day7.University_System.Sections
{
    internal class Course
    {
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        private static Student[] students = new Student[30];
        private static int studentCounter = 0;

        public static void Enroll(Student student)
        {
            try
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student));

                for (int i = 0; i < studentCounter; i++)
                {
                    if (students[i] == student)
                        throw new InvalidOperationException("Student already enrolled.");
                }

                if (studentCounter >= students.Length)
                    throw new InvalidOperationException("Course is full.");

                students[studentCounter++] = student;
                Console.WriteLine($"Student {student.Name} enrolled successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Enrollment error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Enrollment attempt completed.");
            }
        }


        public void Enroll(Student[] newStudents)
        {
            foreach (var s in newStudents)
            {
                try
                {
                    Enroll(s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error enrolling student: {ex.Message}");
                }
            }
        }

        public Student[] GetStudents()
        {
            return students.Take(studentCounter).ToArray();
        }
    }

}
