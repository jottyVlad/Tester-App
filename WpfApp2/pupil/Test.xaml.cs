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
        public Test()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            MySqlConnection conn_2 = DBUtils.GetDBConnection();
            conn_2.Open();

            string sql = $"SELECT * FROM questions WHERE test_id = {TestId}";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader command_reader = command.ExecuteReader();

            List<QuestionClass> ListOfClasses = new List<QuestionClass> { };
            while (command_reader.Read())
            {
                NamelyQuestion = new QuestionClass();
                NamelyQuestion.Id = command_reader.GetInt32(0);
                NamelyQuestion.name = command_reader.GetString(1);
                NamelyQuestion.var1 = command_reader.GetString(2);
                NamelyQuestion.var2 = command_reader.GetString(3);
                NamelyQuestion.var3 = command_reader.GetString(4);
                NamelyQuestion.rightvar = command_reader.GetInt32(5);
                NamelyQuestion.TestId = command_reader.GetInt32(6);
                ListOfClasses.Add(NamelyQuestion);
            }

            InitializeComponent();

            foreach (var i in ListOfClasses)
            {
                this.TextOfQuestion.Text = i.name;
                this.QuestionVar1.Text = i.var1;
                this.QuestionVar2.Text = i.var2;
                this.QuestionVar3.Text = i.var3;
            }

        }

        private void Next_Question_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
