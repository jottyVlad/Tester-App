using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class TestClass
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
    public class QuestionClass
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string var1 { get; set; }
        public string var2 { get; set; }
        public string var3 { get; set; }
        public int rightvar { get; set; }
        public int TestId { get; set; }
        public bool rightAnswer { get; set; }
    }
    public class PostAnswers
    {
        public string PosterName { get; set; }
        public int TestId { get; set; }
        public int AllQuestions { get; set; }
        public int RightAnswers { get; set; }
        public int WrongAnswers { get; set; }
    }

}
