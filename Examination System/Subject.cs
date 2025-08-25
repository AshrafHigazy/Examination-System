using Examination_System.Exams;
using Examination_System.Qustions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {
        public string? SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public Exam? Exam { get; set; }
        public Subject(string? subjectID, string? subjectName)
        {
            #region Protect constructor from invalid values
            //SubjectID
            if (string.IsNullOrWhiteSpace(subjectID))
            {
                throw new ArgumentException("Subject id cant be null", nameof(subjectID));
            }
            //SubjectName
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                throw new ArgumentException("Subject name cant be null", nameof(subjectName));
            }
            #endregion
            SubjectID = subjectID;
            SubjectName = subjectName;
        }
        public override string ToString()
        {
            return $"Subject Id:{SubjectID}\nSubjecr Name:{SubjectName}\nExam Time:{Exam?.ExamTime}";
        }
        public void CreateExam()
        {
            //Detrmine type of exam
            string? type;
            do
            {
                Console.Write("Choose type of exam [ a) Practical | b) Final ]: ");
                type = Console.ReadLine()?.ToLower();
                if(string.IsNullOrWhiteSpace(type) || type[0] != 'a' && type[0] != 'b')
                {
                    Console.Write("Wrong choice! ");
                    type = "";
                }
            } while (string.IsNullOrWhiteSpace(type));
            Console.WriteLine("---------------------------------------------------------");
            //Time Of Exam
            float ExamTime;
            do
            {
                Console.Write("Determine time of the exam in the range (30 : 180 minutes): ");
            }
            while (!float.TryParse(Console.ReadLine(), out ExamTime) || ExamTime < 30 || ExamTime > 180);
            Console.WriteLine("---------------------------------------------------------");
            //Number of Qustions
            int NumQustions = 0;
            do
            {
                Console.Write("Enter The number of qustions: ");
            } while (!int.TryParse(Console.ReadLine(), out NumQustions) || NumQustions<=0);

            Console.Clear();

            Question[] questions = new Question[NumQustions];
            #region Create Preactical exam
            if (type[0] == 'a') //User choose [practical] exam -> so we created exam from [MCQ] type only
            {
                for (int i = 0; i < NumQustions; i++)
                {
                    questions[i] = MCQ.CreateMCQQustion(i + 1);
                }
                Console.Clear();
                Exam = new Practical(DateTime.Now,ExamTime, NumQustions, questions);
            }
            #endregion
            #region Create Final exam
            else//User choose [final] exam -> so we created exam from type [MCQ & T/F] 
            {
                for (int i = 0; i < NumQustions; i++)
                {
                    string? QType;
                    do
                    {
                        Console.Write($"Choose type of Question '{i + 1}' [ a) MCQ - b) True||False ]: ");
                        QType = Console.ReadLine()?.ToLower();
                    } while (string.IsNullOrEmpty(QType) || QType[0] != 'a' && QType[0] != 'b');
                    Console.Clear();
                    if (QType[0] == 'a')
                    {
                        questions[i] = MCQ.CreateMCQQustion(i + 1);
                    }
                    else { questions[i] = TrueOrFalse.CreateTFQuestion(i + 1); }
                    Console.Clear();
                }
                Exam = new Final(DateTime.Now, ExamTime, NumQustions, questions);
            } 
            #endregion
        }
        
        public void StartExam()
        {
            string? start;
            do
            {
                Console.Write("Do You want start exam ? [ a)Yes - b)No ]: ");
                start = Console.ReadLine()?.ToLower();
                if (string.IsNullOrWhiteSpace(start) || start[0] != 'a' && start[0] != 'b')
                {
                    Console.Write("wrong Choice! ");
                    start = "";
                }
            } while (string.IsNullOrWhiteSpace(start) || start[0] != 'a' && start[0] != 'b');
            Console.WriteLine();
            //User wanted start the exam
            if (start[0] == 'b') 
            {
                Console.WriteLine("Exam cancelled..Thank you ^_^");
                return;
            }
            Console.Clear();

            //User want start the exam
            Console.WriteLine(this.ToString());
            Console.WriteLine("-------------------------------");
            if (Exam == null)
            {
                Console.WriteLine("No exams created..!");
                return;
            }
            Exam.StartExam=DateTime.Now;
            float ExamGrade = 0;
            float StudentGrade = 0;

            //Display questions and Take answer id form student
            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                var q = Exam.Questions[i];
                Console.WriteLine($"Question {i+1}) {q}");//Display qeustion and mark

                //Display choices list
                foreach (var answer in q.AnswersList)
                {
                    Console.WriteLine(answer);
                }

                //Take id if student answer from choice list
                Console.Write("Enter your answer: ");
                int userChoice;
                while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > q.AnswersList.Length)
                {
                    Console.Write("Invalid choice, try again: ");
                }
                Console.WriteLine("------------------");
                q.UserAnswer = q.AnswersList[userChoice - 1];

                ExamGrade += q.Mark;
                if (q.UserAnswer.AnswerID == q.RightAnswer.AnswerID)
                {
                    StudentGrade += q.Mark;
                }
            }

            DateTime endExam = DateTime.Now;
            TimeSpan duration = endExam - Exam.StartExam;
            Console.Clear();
            Console.WriteLine($"Exam Finished!\nTime taken: {duration.Minutes} minutes {duration.Seconds} seconds");
            Console.WriteLine($"Your Total Grade: {StudentGrade} from {ExamGrade}");

            //Sort Questions by Marks(ASC)
            Array.Sort(Exam.Questions);
            Exam.ShowExam();
        }
    }
}

