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

namespace WpfApp2.pupil
{
    /// <summary>
    /// Логика взаимодействия для ChooseTest.xaml
    /// </summary>
    public partial class ChooseTest : Window
    {
        public MainWindow MainWind { get; set; }
        public ChooseTest()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string sql = "SELECT * FROM packets";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader cmd_reader = command.ExecuteReader();
            InitializeComponent();

            ObservableCollection<string> list = new ObservableCollection<string>();

            while (cmd_reader.Read())
            {
                int cmd_reader_int = cmd_reader.GetInt32(0);
                string cmd_reader_string = cmd_reader.GetString(1);

                TestClass ClassOfTests = new TestClass();
                ClassOfTests.Id = cmd_reader_int;
                ClassOfTests.name = cmd_reader_string;

                list.Add(cmd_reader_string);
            }
            this.PacketsToPassage.ItemsSource = list;

            this.Closing += ChooseTest_Closing;
        }

        private void ChooseTest_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MainWind.Show();
            }
            catch
            {
                return;
            }
        }

        private void PassageChoicePacket_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            string sql = $"SELECT id FROM packets WHERE name = '{this.PacketsToPassage.Text}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            int command_query_selectId = Convert.ToInt32(command.ExecuteScalar());

            Test TestWind = new Test(command_query_selectId);

            this.Hide();
            TestWind.ShowDialog();
        }
    }
}
