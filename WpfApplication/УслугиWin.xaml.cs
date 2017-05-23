using System.Linq;
using System.Windows;
using Database;
//using Database.EFModel;
using Logics.Services;
using WpfApplication.Helpers;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class УслугиWin : Window
    {
        private Услуга serv;

        public УслугиWin()
        {
            InitializeComponent();
            //this._code = code;
            var autoServ = ServiceLocator.GetService<Услуга>();
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var услуги = autoServ.ReadAll();
                услуги.ToList().ForEach(c => list_of_service.Items.Add(c));//.ФИО_клиента));

                //.First().ФИО_клиента;//должен выводится весь список
                //description.AppendText(автозаправка.Описание);
                //name_of_client.Text = постоянныеклиенты.ФИО_клиента;
                //автозаправка.Номер_телефона = "12344567";
                //var auto = autoServ.Uow.Db.Автозаправка.Find(автозаправка.Код); //Автозаправки //Save(автозаправка, автозаправка.Номер_автозаправки);//.Value);
                //autoServ.Uow.Save();

            }
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

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            УслугаWin winTool = new УслугаWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ЧекWin winTool = new ЧекWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
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
            //list_of_products.Items.Clear();
            list_of_service.Items.Remove(list_of_service.SelectedItem);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            УслугаWin winTool = new УслугаWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
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

                постоянныеклиенты.ToList().ForEach(c => list_of_service.Items.Add(c));//.ФИО_клиента));

                //for (int i = 0; i < spp.Length; i++)
                //{
                //    spp[i] = list_of_clients.Items[i].ToString();
                //    if (name_of_client.Text.GetHashCode() == spp[i].GetHashCode())
                //    {
                //        постоянныеклиенты.ToList().ForEach(c => list_of_clients.Items.Add(spp));
                //    }
                //}
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
            Settings.Check.ЧекУслуга.Add(new ЧекУслуга() { Услуга = serv, Чек = Settings.Check });
            //.AddRange(prods);.ToList()
        }
    }
}
