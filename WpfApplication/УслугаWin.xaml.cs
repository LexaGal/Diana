using System.Windows;
using Database;
using Logics.Services;
using WpfApplication.Helpers;
using System.Windows.Input;
using System;

namespace WpfApplication
{
    public partial class УслугаWin : Window
    {
        public УслугаWin()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            УслугиWin winTool = new УслугиWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var serv = new Услуга()
            {
                название_услуги = name.Text,
                стоимость = decimal.Parse(value.Text)
            };
            var servServ = ServiceLocator.GetService<Услуга>();
            using (servServ.Uow.Db = new АвтозаправкиEntities())
            {
                servServ.Save(serv);
            }
            //if (ServiceLocator.Услуга != null)
            //{

            //}
            //MessageBox.Show("Услуга добавлена в чек.");
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
            
                KeyConverter KC = new KeyConverter();
                char number = Convert.ToChar(KC.ConvertToString(e.Key));
                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
        }
    }
}
