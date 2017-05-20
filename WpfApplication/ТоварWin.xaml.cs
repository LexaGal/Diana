using Database;
using Logics.Services;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for Window11.xaml
    /// </summary>
    public partial class ТоварWin : Window
    {
        //private int _code;
        public ТоварWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var prod = new Товар()
            {
                код_товара = int.Parse(product_code.Text),
                название_товара = name.Text,
                количесвто = int.Parse(amount.Text),
                стоимость = decimal.Parse(value.Text)
            };

            var prodServ = ServiceLocator.GetService<Товар>();
            using (prodServ.Uow.Db = new АвтозаправкиEntities())
            {
                prodServ.Save(prod);
            }
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
