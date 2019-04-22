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
    /// Логика взаимодействия для Teacher_1.xaml
    /// </summary>
    public partial class Teacher : Window
    {
        public Teacher teacherwind { get; }
        public Teacher()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //teacherwind.Close();
            AddPacket AddPacketWindow = new AddPacket();
            AddPacketWindow.ShowDialog();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            RemovePacket RemovePacketWindow = new RemovePacket();
            RemovePacketWindow.ShowDialog();
        }
    }
}
