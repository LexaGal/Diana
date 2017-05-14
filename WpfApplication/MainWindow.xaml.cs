using System.Linq;
using System.Windows;
using System.Windows.Controls;
//using Database.EFModel;
using Logics.Services;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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
            //Создание нового окна.
            АвтозаправкаWin winTool = new АвтозаправкаWin(textBox.Text);
            // Назначение текущего окна владельцем.
            winTool.Owner = this;
            // Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }
    }
}
