using System.Linq;
using System.Windows;
using Database;
using Logics.Services;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public partial class УслугиWin : Window
    {
        private Услуга serv;

        public УслугиWin()
        {
            InitializeComponent();
            var autoServ = ServiceLocator.GetService<Услуга>();
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var услуги = autoServ.ReadAll();
                услуги.ToList().ForEach(c => list_of_service.Items.Add(c));
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var prodServ = ServiceLocator.GetService<Услуга>();
            using (prodServ.Uow.Db = new АвтозаправкиEntities())
            {
                var id = (list_of_service.SelectedItem as Услуга).код_услуги;
                prodServ.Delete(id);
            }
            list_of_service.Items.Remove(list_of_service.SelectedItem);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            УслугаWin winTool = new УслугаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            var autoServ = ServiceLocator.GetService<Услуга>() as УслугаService;
            var n = name_of_service.Text;
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var постоянныеклиенты = autoServ.ReadSome(n);
                list_of_service.Items.Clear();
                постоянныеклиенты.ToList().ForEach(c => list_of_service.Items.Add(c));
            }
        }

        private void list_of_serviceSelect(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                serv = e.AddedItems[0] as Услуга;
                value.Text = serv.стоимость.Value.ToString();
            }
        }

        private void insert_serv_check(object sender, RoutedEventArgs e)
        {
            var ch = Settings.Check;
            var checkServ = ch.ЧекУслуга.SingleOrDefault(t => t.Услуга.код_услуги == serv.код_услуги);

            if (checkServ == null)
            {
                ch.ЧекУслуга.Add(new ЧекУслуга() { Услуга = serv, Чек = Settings.Check });
            }
        }

        private void value_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
