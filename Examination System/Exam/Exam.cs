using Examination_System.Qustions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    //Using abstract to pan take an object-> becouse we need it like begging and complet it in type of exam
    abstract class Exam
    {
        public DateTime StartExam { get; set; } //Start time counter when exam started
        public float ExamTime { get; set; } 
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }
        public Exam(DateTime startExam, float examTime, int numberOfQuestions, Question[] questions)
        {
            #region Protect constructor from invalid values
            //Number of Questions
            if (numberOfQuestions <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfQuestions),"Number of questions must be > 0");
            }
            //Exam Time
            if(examTime <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfQuestions), "Exam time must be > 0");
            }
            //Qustions
            if (questions == null || questions.Length == 0)
            {
                throw new ArgumentException("Questions cant be empty!", nameof(questions));
            } 
            #endregion
            StartExam = startExam;
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }
        //Method it will be override to display exam
        public abstract void ShowExam();
    }
}
