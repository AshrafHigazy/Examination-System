namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using try-catch for unexpected errors
            try
            {
                Subject subject = new Subject("CS241", "Object-Oriented Programming");
                subject.CreateExam();
                subject.StartExam();
            }
            catch (Exception exception)
            {

                Console.WriteLine("Unexpected Error hape..!");
                Console.WriteLine($"Details: {exception.Message}");
            }
            finally
            {
                Console.WriteLine("\nGood Work,Thank You ^_^. Press any key to exit...!");
                Console.ReadKey();
            }
        }
    }
}
