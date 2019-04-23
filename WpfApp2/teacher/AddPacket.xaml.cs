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
using WpfApp2;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace WpfApp2.teacher
{
    /// <summary>
    /// Логика взаимодействия для AddPacket.xaml
    /// </summary>
    public partial class AddPacket : Window
    {
        public Teacher TeacherWind { get; set; }
        public string NamePacket { get; set; }
        public AddPacket()
        {
            InitializeComponent();

            this.Closing += AddPacket_Closing;
        }

        private void AddPacket_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string sql = "SELECT name FROM packets";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader command_reader = command.ExecuteReader();

            MySqlConnection conn_2 = DBUtils.GetDBConnection();
            conn_2.Open();
            sql = "SELECT COUNT(*) FROM packets";
            command = new MySqlCommand(sql, conn_2);
            int command_count = Convert.ToInt32(command.ExecuteScalar());

            var list = new List<string>();

            while (command_reader.Read())
            {
                list.Add(command_reader.GetString(0));
            }

            conn.Close();

            if(this.NameOfPacket.Text != "" && !(list.Contains(this.NameOfPacket.Text)))
            {
                conn = DBUtils.GetDBConnection();
                conn.Open();
                NamePacket = this.NameOfPacket.Text;
                sql = $"INSERT INTO packets (id, name) VALUES(null, '{NamePacket}')";
                command = new MySqlCommand(sql, conn);
                int cmd_line_insert = command.ExecuteNonQuery();

                sql = $"SELECT id FROM packets WHERE name = '{NamePacket}'";
                command = new MySqlCommand(sql, conn);
                int cmd_line_select = (int)command.ExecuteScalar();

                AnswerPage CreateAnswers = new AnswerPage();
                CreateAnswers.PackageID = cmd_line_select;

                CreateAnswers.TeacherWind = this.TeacherWind;

                this.Hide();

                CreateAnswers.ShowDialog();
            }
        }
    }
}
