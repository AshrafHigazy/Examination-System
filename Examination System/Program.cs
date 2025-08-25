namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject("CS241", "Object-Oriented Programming");
            subject.CreateExam();
            subject.StartExam();
        }
    }
}
