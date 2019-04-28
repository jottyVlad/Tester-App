using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Teacher_1.xaml
    /// </summary>
    public partial class Teacher : Window
    {
        public MainWindow MainWind { get; set; }
        public Teacher()
        {
            InitializeComponent();
            this.Closing += Teacher_Closing;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddPacket AddPacketWindow = new AddPacket();
            AddPacketWindow.TeacherWind = this;
            AddPacketWindow.ShowDialog();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RemovePacket RemovePacketWindow = new RemovePacket();
            RemovePacketWindow.TeacherWind = this;
            RemovePacketWindow.ShowDialog();
        }
        private void Teacher_Closing(object sender, CancelEventArgs e)
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

        private void ShowResults_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChooseResults ChooseResultsWind = new ChooseResults();
            ChooseResultsWind.TeacherWind = this;
            ChooseResultsWind.Show();
        }
    }
}
