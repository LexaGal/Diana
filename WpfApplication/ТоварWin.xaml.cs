using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for Window11.xaml
    /// </summary>
    public partial class ТоварWin : Window
    {
        public ТоварWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ТоварыWin winTool = new ТоварыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }
    }
}
