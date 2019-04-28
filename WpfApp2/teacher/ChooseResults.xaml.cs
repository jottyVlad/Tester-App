using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2.teacher
{
    /// <summary>
    /// Логика взаимодействия для ChooseResults.xaml
    /// </summary>
    public partial class ChooseResults : Window
    {
        public Teacher TeacherWind { get; set; }
        public ChooseResults()
        {
            InitializeComponent();
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string sql = "SELECT * FROM packets";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader command_read = command.ExecuteReader();
            ObservableCollection<string> TestsNames = new ObservableCollection<string>();
            while (command_read.Read())
            {
                TestsNames.Add(command_read.GetString(1));
            }
            TestsForListen.ItemsSource = TestsNames;

            this.Closing += ChooseResults_Closing;
        }

        private void ChooseResults_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                TeacherWind.Show();
            }
            catch
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TestsForListen.SelectedItem != null)
            {
                this.Hide();
                Results ResultsWind = new Results(TestsForListen.SelectedItem.ToString());
                ResultsWind.ChooseResultsWind = this;
                ResultsWind.ShowDialog();
            }
        }
    }
}
