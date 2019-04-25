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
        public List<QuestionClass> ListOfClasses { get; set; }

        int count = 2;

        public Test(int TestId)
        {
            this.TestId = TestId;

            /*MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            string sql = $"SELECT * FROM questions WHERE `test_id` = {TestId}";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader cmd_reader = command.ExecuteReader();

            List<QuestionClass> ListOfClasses = new List<QuestionClass> { };
            while (cmd_reader.Read() )
            {
                NamelyQuestion = new QuestionClass();
                NamelyQuestion.Id = cmd_reader.GetInt32(0);
                NamelyQuestion.name = cmd_reader.GetString(1);
                NamelyQuestion.var1 = cmd_reader.GetString(2);
                NamelyQuestion.var2 = cmd_reader.GetString(3);
                NamelyQuestion.var3 = cmd_reader.GetString(4);
                NamelyQuestion.rightvar = cmd_reader.GetInt32(5);
                NamelyQuestion.TestId = cmd_reader.GetInt32(6);
                ListOfClasses.Add(NamelyQuestion);
            }

            this.ListOfClasses = ListOfClasses;*/

            InitializeComponent();

            Click();
        }

        private void Next_Question_Click(object sender, RoutedEventArgs e)
        {
            if (this.First.IsChecked == true || this.Second.IsChecked == true || this.Third.IsChecked == true)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                string sql = $"SELECT * FROM questions WHERE test_id = {TestId} AND question_id = {count}";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader command_reader = command.ExecuteReader();
                while (command_reader.Read())
                {
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

        private void Click()
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
