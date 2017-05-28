using System.Windows;
using System.Windows.Controls;
using Database;
using Logics.Services;

namespace WpfApplication
{
    public partial class СерверWin : Window
    {
        public СерверWin()
        {
            InitializeComponent();
        }
               
        private void average_profit_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void Update(object sender, SelectionChangedEventArgs e)
        {
            var c = sender as Calendar;
            var date = c.SelectedDate.Value;
            var month = date.Month;
            var day = radioMonthDay.IsChecked.Value ? date.Day : 0;

            var checkServ = ServiceLocator.GetService<Чек>() as ЧекService;
            using (checkServ.Uow.Db = new АвтозаправкиEntities())
            {
                month_average_profit.Text = $"{checkServ.GetChecksSum(month, day):#0.00}";
                profit_for_fuel.Text = $"{checkServ.GetFuelChecksSum(month, day):#0.00}";
                profit_for_goods_and_services.Text = $"{checkServ.GetProdServChecksSum(month, day):#0.00}";
            }
        }

        private void MonthCheck(object sender, RoutedEventArgs e)
        {
            if (radioMonthDay != null) radioMonthDay.IsChecked = false;
        }

        private void MonthDayCheck(object sender, RoutedEventArgs e)
        {
            if (radioMonth != null) radioMonth.IsChecked = false;
        }
    }
}
