
using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher myTeacher = new Teacher
            {
                Name = "Starlyn",
                Subject = "C#"
            };

            Console.WriteLine("Everything is working! Teacher: " + myTeacher.Name);
            Console.ReadKey();
        }
    }
}   