using Database;
using Logics.Services;
using System.Linq;
using System.Windows;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public partial class ЧекWin : Window
    {
        decimal sumProd = 0, sumServ = 0, sumFuel = 0;

        public ЧекWin()
        {
            InitializeComponent();
            customer_name.Text = Settings.Check.Постоянные_клиенты?.ФИО_клиента;
            Settings.Check.ЧекТовар.ToList().ForEach(c =>
            {
                list_of_goods.Items.Add(c);
                sumProd += c.Товар.стоимость.Value*c.кол_во;
            });
            total_price_of_goods.Text = sumProd.ToString("#0.00");
            Settings.Check.ЧекУслуга.ToList().ForEach(u =>
            {
                list_of_services.Items.Add(u);
                sumServ += u.Услуга.стоимость.Value;
            });
            total_price_of_servs.Text = sumServ.ToString("#0.00");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void m92_Click(object sender, RoutedEventArgs e)
        {
            Топливо92 winTool = new Топливо92();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void m95_Click(object sender, RoutedEventArgs e)
        {
            Топливо95 winTool = new Топливо95();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void mdiz_Click(object sender, RoutedEventArgs e)
        {
            Дизельное winTool = new Дизельное();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            КлиентыWin winTool = new КлиентыWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void mFile_Click(object sender, RoutedEventArgs e)
        {
        }

        private void tov_Click(object sender, RoutedEventArgs e)
        {
            ТоварыWin winTool = new ТоварыWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void usl_Click(object sender, RoutedEventArgs e)
        {
            УслугиWin winTool = new УслугиWin();
            winTool.Owner = this;
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

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void calculate_all(object sender, RoutedEventArgs e)
        {
            decimal sum = sumProd + sumFuel + sumServ;
            total_price.Text = $"{sum}";
            decimal disc = Settings.Check.Постоянные_клиенты.Количество_посещений.Value%15;
            decimal total = sum - sum*disc/100;
            discount.Text = $"-{disc}% = {total}";
            Settings.Check.стоимость = total;
            var checkServ = ServiceLocator.GetService<Чек>();
            using (checkServ.Uow.Db = new АвтозаправкиEntities())
            {
                checkServ.Save(Settings.Check);
                Settings.Check = new Чек();
            }
        }
    }
}