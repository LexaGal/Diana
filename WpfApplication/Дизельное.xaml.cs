using Database;
using Logics.Services;
using System.Linq;
using System.Windows;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public partial class Дизельное : Window
    {
        private Топливо t;

        public Дизельное()
        {
            InitializeComponent();
            var fuelServ = ServiceLocator.GetService<Топливо>();
            using (fuelServ.Uow.Db = new АвтозаправкиEntities())
            {
                t = fuelServ.ReadAll().ToList().Single(f => f.название_топлива == "Дизельное");
                value.Text = t.стоимость.ToString();
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            Settings.Check.Топливо = t;
            Settings.Check.кол_во_топлива = int.Parse(amount.Text);
        }
    }
}
