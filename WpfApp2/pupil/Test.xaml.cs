using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.pupil
{
    /// <summary>
    /// Логика взаимодействия для Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public int TestId { get; set; }
        public TestClass NamelyTest { get; set; }
        public QuestionClass NamelyQuestion { get; set; }
        public ChooseTest ChooseTestWind { get; set; }

        PostAnswers AnswersPupilClass = new PostAnswers();

        int count = 2;

        int ThisChecked = 0;

        public Test(int TestId)
        {
            this.TestId = TestId;

            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            string sql = $"SELECT COUNT(*) FROM questions WHERE `test_id` = {TestId}";
            MySqlCommand command = new MySqlCommand(sql, conn);
            int cmd_numberOfQuestions = Convert.ToInt32(command.ExecuteScalar());

            AnswersPupilClass.TestId = TestId;
            AnswersPupilClass.AllQuestions = cmd_numberOfQuestions;

            InitializeComponent();

            FirstQuestion();
        }

        private void Next_Question_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn_2 = DBUtils.GetDBConnection();
            conn_2.Open();
            string sql = $"SELECT name FROM questions WHERE test_id = {TestId} AND question_id = {count}";
            MySqlCommand command = new MySqlCommand(sql, conn_2);
            var command_execute = command.ExecuteScalar();
            if (command_execute == null)
            {
                if (this.First.IsChecked == true || this.Second.IsChecked == true || this.Third.IsChecked == true)
                {

                    if (this.First.IsChecked == true)
                        ThisChecked = 1;
                    else if (this.Second.IsChecked == true)
                        ThisChecked = 2;
                    else if (this.Third.IsChecked == true)
                        ThisChecked = 3;

                    MySqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();
                    sql = $"SELECT * FROM questions WHERE test_id = {TestId} AND question_id = {count-1}";
                    command = new MySqlCommand(sql, conn);
                    MySqlDataReader command_reader = command.ExecuteReader();
                    while (command_reader.Read())
                    {
                        if (ThisChecked == command_reader.GetInt32(5))
                        {
                            AnswersPupilClass.RightAnswers++;
                        }
                        else
                        {
                            AnswersPupilClass.WrongAnswers++;
                        }
                    }
                }
                this.Hide();
                writeName WriteNameWind = new writeName(AnswersPupilClass);
                WriteNameWind.TestWind = this;
                this.Hide();
                WriteNameWind.ShowDialog();
            }
            else
            {
                if (this.First.IsChecked == true || this.Second.IsChecked == true || this.Third.IsChecked == true)
                {

                    if (this.First.IsChecked == true) 
                        ThisChecked = 1;
                    else if (this.Second.IsChecked == true)
                        ThisChecked = 2;
                    else if (this.Third.IsChecked == true)
                        ThisChecked = 3;
                    
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();
                    sql = $"SELECT * FROM questions WHERE test_id = {TestId} AND question_id = {count}";
                    command = new MySqlCommand(sql, conn);
                    MySqlDataReader command_reader = command.ExecuteReader();
                    while (command_reader.Read())
                    {
                        if(ThisChecked == command_reader.GetInt32(5))
                        {
                            AnswersPupilClass.RightAnswers++;
                        }
                        else
                        {
                            AnswersPupilClass.WrongAnswers++;
                        }
                        this.TextOfQuestion.Text = command_reader.GetString(1);
                        this.QuestionVar1.Text = command_reader.GetString(2);
                        this.QuestionVar2.Text = command_reader.GetString(3);
                        this.QuestionVar3.Text = command_reader.GetString(4);
                    }
                    count++;
                }
                else
                {
                    return;
                }
            }

        }

        private void FirstQuestion()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string sql = $"SELECT * FROM questions WHERE test_id = {TestId} AND question_id = 1";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader command_reader = command.ExecuteReader();
            while (command_reader.Read())
            {
                this.TextOfQuestion.Text = command_reader.GetString(1);
                this.QuestionVar1.Text = command_reader.GetString(2);
                this.QuestionVar2.Text = command_reader.GetString(3);
                this.QuestionVar3.Text = command_reader.GetString(4);
            }
        }
    }
}
