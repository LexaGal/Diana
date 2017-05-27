using Database;
using Logics.Services;
using System.Windows;

namespace WpfApplication
{
    public partial class ТоварWin : Window
    {
        public ТоварWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var prod = new Товар()
            {
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
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
    }
}
