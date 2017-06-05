using Database;
using Logics.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
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
            if (Settings.Check.Топливо != null)
            {
               
            }
            MessageBox.Show("Топливо добавлено в чек.");
        }

        private void amount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void amount_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                KeyConverter KC = new KeyConverter();
                char number = Convert.ToChar(KC.ConvertToString(e.Key));
                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }
    }
}
