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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.teacher;
using WpfApp2.pupil;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            foreach (Window w in App.Current.Windows)
                w.Close();
        }

        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            if(this.ComboBoxAuth.SelectedItem == Teacher)
            {
                this.Hide();
                Teacher TeacherWind = new Teacher();
                TeacherWind.MainWind = this;
                TeacherWind.ShowDialog();
            }
            if(this.ComboBoxAuth.SelectedItem == Pupil)
            {
                this.Hide();
                ChooseTest chooseTestWindow = new ChooseTest();
                chooseTestWindow.MainWind = this;
                chooseTestWindow.ShowDialog();
            }
        }
    }
}
