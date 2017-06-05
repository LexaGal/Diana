using Database;
using Logics.Services;
using System;
using System.Windows;
using System.Windows.Input;

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

        private void name_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                KeyConverter KC = new KeyConverter();
                char number = Convert.ToChar(KC.ConvertToString(e.Key));
                if (!Char.IsLetter(number))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }

        private void value_KeyDown(object sender, KeyEventArgs e)
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

        private void amount_KeyDown(object sender, KeyEventArgs e)
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
