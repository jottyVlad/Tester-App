using System.Windows;
using WpfApp2;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System;

namespace WpfApp2.teacher
{
    /// <summary>
    /// Логика взаимодействия для RemovePacket.xaml
    /// </summary>
    public partial class RemovePacket : Window
    {
        int IdPacket { get; set; }
        public Teacher TeacherWind { get; set; }
        public RemovePacket()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            MySqlConnection conn_1 = DBUtils.GetDBConnection();
            conn_1.Open();

            string sql = "SELECT name FROM packets";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader cmd_reader = command.ExecuteReader();

            InitializeComponent();

            ObservableCollection<string> list = new ObservableCollection<string>();

            while (cmd_reader.Read())
            {
                string cmd_reader_string = cmd_reader.GetString(0);

                list.Add(cmd_reader_string);
            }
            this.PacketsToRemove.ItemsSource = list;

            this.Closing += RemovePacket_Closing;
        }

        private void RemovePacket_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void DeleteChoicePacket_Click(object sender, RoutedEventArgs e)
        {
            if(this.PacketsToRemove.SelectedItem != null)
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                string sql = $"SELECT id FROM packets WHERE name = '{this.PacketsToRemove.Text}'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                int command_query_selectId = Convert.ToInt32(command.ExecuteScalar());

                sql = $"DELETE FROM packets WHERE name = '{this.PacketsToRemove.Text}'";
                command = new MySqlCommand(sql, conn);
                int command_query_delete_packet = command.ExecuteNonQuery();

                sql = $"DELETE FROM questions WHERE test_id = {command_query_selectId}";
                command = new MySqlCommand(sql, conn);
                int command_query_delete_questions = command.ExecuteNonQuery();

                this.PacketsToRemove.SelectedItem = null;
            }
        }
    }
}
