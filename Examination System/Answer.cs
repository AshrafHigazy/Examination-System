using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answer
    {
        //Read only propertes
        public int AnswerID { get;}
        public string AnswerText { get;}
        public Answer(int answerID, string answerText)
        {

            #region Protected Constructor from invalid inputs
            if (answerID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(answerID), "AnswerID must be < zero");
            }
            if (string.IsNullOrWhiteSpace(answerText))
            {
                throw new ArgumentException("AnswerText Cant be Null", nameof(answerText));
            }
            #endregion

            AnswerID = answerID;
            AnswerText = answerText;
        }
        public override string ToString()
        {
            return $"{AnswerID}) {AnswerText}";
        }
    }
}
