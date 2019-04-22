using MySql.Data.MySqlClient;
using System.Windows;

namespace WpfApp2.teacher
{
    /// <summary>
    /// Логика взаимодействия для AnswerPage_.xaml
    /// </summary>
    public partial class AnswerPage : Window
    {
        public int PackageID { get; set; }
        int rightvar = 0;
        public AnswerPage()
        {
            InitializeComponent();
        }

        private void Next_Answer_Click(object sender, RoutedEventArgs e)
        {
            string AskNeverSpaces = this.TitleOfQuestion.Text.Replace(" ", "");
            string Var1NeverSpaces = this.Var1.Text.Replace(" ", "");
            string Var2NeverSpaces = this.Var2.Text.Replace(" ", "");
            string Var3NeverSpaces = this.Var3.Text.Replace(" ", "");

            string Ask = this.TitleOfQuestion.Text;
            string Var1 = this.Var1.Text;
            string Var2 = this.Var2.Text;
            string Var3 = this.Var3.Text;

            if (AskNeverSpaces != "" && Var1NeverSpaces != "" && Var2NeverSpaces != "" && Var3NeverSpaces != "")
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();
                if (this.First.IsChecked == true)
                {
                    rightvar = 1;
                }
                else if (this.Second.IsChecked == true)
                {
                    rightvar = 2;
                }
                else if (this.Third.IsChecked == true)
                {
                    rightvar = 3;
                }
                string sql = $"INSERT INTO questions(id, name, var1, var2, var3, rightvar, test_id) VALUES(null, '{Ask}', '{Var1}', '{Var2}', '{Var3}', {rightvar}, {PackageID})";
                MySqlCommand command = new MySqlCommand(sql, conn);
                int cmd_line = command.ExecuteNonQuery();

                this.TitleOfQuestion.Text = "";
                this.Var1.Text = "";
                this.Var2.Text = "";
                this.Var3.Text = "";
                this.First.IsChecked = false;
                this.Second.IsChecked = false;
                this.Third.IsChecked = false;
            }
        }
    }
}
