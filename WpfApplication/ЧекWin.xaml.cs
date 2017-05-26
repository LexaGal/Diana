using Database;
using Logics.Services;
using System.Linq;
using System.Windows;
using WpfApplication.Helpers;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
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
                sumProd += c.Товар.стоимость.Value * c.кол_во;
            });
            total_price_of_goods.Text = sumProd.ToString("#0.00");

            Settings.Check.ЧекУслуга.ToList().ForEach(u => {
                list_of_services.Items.Add(u);
                sumServ += u.Услуга.стоимость.Value ;
            });

            //sumFuel = 
            
            total_price_of_servs.Text = sumServ.ToString("#0.00");
            //Settings.Check.ЧекУслуга.ToList().ForEach(u => {
            //    list_of_services.Items.Add(u);
            //    sumServ += u.Услуга.стоимость.Value;
            //});

            ////sumFuel = 

            //total_price_of_servs.Text = sumServ.ToString("#0.00");
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
            ТоварыWin winTool = new ТоварыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void usl_Click(object sender, RoutedEventArgs e)
        {
            УслугиWin winTool = new УслугиWin();
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

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void calculate_all(object sender, RoutedEventArgs e)
        {
            decimal sum = sumProd + sumFuel + sumServ; //Settings.Check
            total_price.Text = $"{sum}";

            decimal disc = Settings.Check.Постоянные_клиенты.Количество_посещений.Value % 15;
            decimal total = sum - sum * disc / 100;

            discount.Text = $"-{disc}% = {total}";

            Settings.Check.стоимость = total;

            var checkServ = ServiceLocator.GetService<Чек>();
            using (checkServ.Uow.Db = new АвтозаправкиEntities())
            {
                checkServ.Save(Settings.Check); //Settings.Check.код_чека);
            }
            //Database       
        }
    }
}
