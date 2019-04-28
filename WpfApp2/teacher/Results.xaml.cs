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

namespace WpfApp2.teacher
{
    /// <summary>
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public ChooseResults ChooseResultsWind { get; set; }
        public Results(string name)
        {
            InitializeComponent();
            
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string sql = $"SELECT id FROM packets WHERE name = '{name}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            int TestId = Convert.ToInt32(command.ExecuteScalar());

            sql = $"SELECT * FROM posters WHERE TestId = {TestId}";
            command = new MySqlCommand(sql, conn);
            MySqlDataReader command_reader = command.ExecuteReader();
            while(command_reader.Read())
            {
                Label Result = new Label();
                Result.Content = $"{command_reader.GetString(1)}; Тест - {name}; Правильных ответов - {command_reader.GetString(3)}; Неправильных ответов - {command_reader.GetString(4)}; Вопросов в тесте - {command_reader.GetString(5)}";
                this.ResultsStackPanel.Children.Add(Result);
            }

            this.Closing += Results_Closing;

        }

        private void Results_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ChooseResultsWind.Show();
            }
            catch
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
