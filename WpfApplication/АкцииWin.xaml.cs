using System.Windows;
namespace WpfApplication
{
    public partial class АкцииWin : Window
    {
        public АкцииWin()
        {
            InitializeComponent();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
