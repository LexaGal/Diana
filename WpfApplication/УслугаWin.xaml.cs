using System.Windows;
using Database;
using Logics.Services;
using WpfApplication.Helpers;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for Window10.xaml
    /// </summary>
    public partial class УслугаWin : Window
    {
        public УслугаWin()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
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
            var serv = new Услуга()
            {
                код_услуги = int.Parse(service_code.Text),
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
