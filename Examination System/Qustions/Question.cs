using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Qustions
{
    abstract class Question:IComparable<Question>
    {
        public string HeaderOfQusetion { get; }
        public string BodyOfQusetion { get; }
        public float Mark { get; }
        public Answer[] AnswersList { get; }
        public Answer RightAnswer { get; }
        public Answer? UserAnswer { get; set; }

        public Question(string headerOfQusetion, string bodyOfQusetion, float mark, Answer[] answersList, Answer rightAnswer)
        {
            #region Protect constructor from invalid values
            //Header
            if (string.IsNullOrWhiteSpace(headerOfQusetion))
            {
                throw new ArgumentException("Header cant be null", nameof(headerOfQusetion));
            }
            //Body
            if (string.IsNullOrWhiteSpace(bodyOfQusetion))
            {
                throw new ArgumentException("Body cant be null", nameof(bodyOfQusetion));
            }
            //Mark
            if (mark <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(mark), "Mark must be > 0");
            }
            //AnswerList
            if (answersList == null || answersList.Length == 0)
            {
                throw new ArgumentException("Answers List cant be null", nameof(answersList));
            }
            //RightQuestion
            if (rightAnswer == null || !answersList.Contains(rightAnswer))
            {
                throw new ArgumentException("Right Answer must be one of answers", nameof(rightAnswer));
            }

            #endregion
            HeaderOfQusetion = headerOfQusetion;
            BodyOfQusetion = bodyOfQusetion;
            Mark = mark;
            AnswersList = answersList;
            RightAnswer = rightAnswer;
        }
        // Sorting by Marks
        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return this.Mark.CompareTo(other.Mark);
        }
        public override string ToString()
        {
            return $"{BodyOfQusetion}   (Mark: {Mark})";
        }
        public abstract void ShowQustion();
    }
}
