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
    /// Логика взаимодействия для YourResults.xaml
    /// </summary>
    public partial class YourResults : Window
    {
        public writeName WriteNameWind { get; set; }
        public YourResults(int WrongAnswers, int RightAnswers, int AllQuestions)
        {
            InitializeComponent();
            this.Results.Text = $"Верно {RightAnswers} из {AllQuestions}. {WrongAnswers} неверных ответов";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteNameWind.TestWind.ChooseTestWind.MainWind.Show();
            WriteNameWind.TestWind.ChooseTestWind.Close();
            WriteNameWind.TestWind.Close();
            WriteNameWind.Close();
            this.Close();
        }
    }
}
