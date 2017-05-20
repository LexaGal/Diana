using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class ЧекWin : Window
    {
        public ЧекWin()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void m92_Click(object sender, RoutedEventArgs e)
        {
            //Создание нового окна.
            //Создание нового окна.
            Топливо92 winTool = new Топливо92();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void m95_Click(object sender, RoutedEventArgs e)
        {
            Топливо95 winTool = new Топливо95();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }
    

        private void mdiz_Click(object sender, RoutedEventArgs e)
        {
        Дизельное winTool = new Дизельное();
        //Назначение текущего окна владельцем.
        winTool.Owner = this;
        //Отображение окна, принадлежащего окну-владельцу.
        winTool.Show();
        this.Hide();
    }


        private void b_Click(object sender, RoutedEventArgs e)
        {
            КлиентыWin winTool = new КлиентыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

      

        private void mFile_Click(object sender, RoutedEventArgs e)
        {

        }

     

      
        private void tov_Click(object sender, RoutedEventArgs e)
        {
            ТоварWin winTool = new ТоварWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void usl_Click(object sender, RoutedEventArgs e)
        {
            УслугаWin winTool = new УслугаWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
