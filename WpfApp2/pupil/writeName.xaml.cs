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
    /// Логика взаимодействия для writeName.xaml
    /// </summary>
    public partial class writeName : Window
    {
        protected PostAnswers PupilPostAnswers { get; set; }
        public Test TestWind { get; set; }
        public writeName(PostAnswers PupilPostAnswers)
        {
            this.PupilPostAnswers = PupilPostAnswers;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.PupilName.Text != "")
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                string sql = $"INSERT INTO posters(id, PupilName, TestId, RightAnswers, WrongAnswers, AllQuestions) VALUES(null, '{this.PupilName.Text}', {PupilPostAnswers.TestId}, {PupilPostAnswers.RightAnswers}, {PupilPostAnswers.WrongAnswers}, {PupilPostAnswers.AllQuestions})";
                MySqlCommand command = new MySqlCommand(sql, conn);
                int command_nonquery = command.ExecuteNonQuery();
                YourResults ResultsWind = new YourResults(PupilPostAnswers.WrongAnswers, PupilPostAnswers.RightAnswers, PupilPostAnswers.AllQuestions);
                ResultsWind.WriteNameWind = this;
                this.Hide();
                ResultsWind.ShowDialog();
            }
        }
    }
}
