using System.Windows;
using Database;
using Logics.Services;

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
        }
    }
}
