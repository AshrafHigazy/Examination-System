using Examination_System.Qustions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    internal class Practical : Exam
    {
        public Practical(DateTime startExam, float examTime, int numberOfQuestions, Question[] questions) : base(startExam, examTime, numberOfQuestions, questions)
        {
        }
        public override void ShowExam()
        {
            Console.WriteLine("\n--------------------[ Practical Exam (Model Answer) ]--------------------\n");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Question q = Questions[i];
                Console.WriteLine($"Qustion {i + 1}) {q.BodyOfQusetion}      Mark({q.Mark})");
                Console.WriteLine("------------------");
                Console.WriteLine($"Your Answer is ({q.UserAnswer?.AnswerText})");
                Console.WriteLine($"Right Answer is ({q.RightAnswer.AnswerText})");
                //Check student grade is question
                float grade = (q.UserAnswer?.AnswerID == q.RightAnswer.AnswerID) ? q.Mark : 0;
                Console.WriteLine($"Your grade= {grade}");
                Console.WriteLine("----------------------------\n");
            }
        }
    }
}
