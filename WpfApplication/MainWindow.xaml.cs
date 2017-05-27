using System.Windows;
using System.Windows.Controls;

namespace WpfApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin(int.Parse(entrance.Text));
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
    }
}
