using System.Linq;
using System.Windows;
using Database;
//using Database.EFModel;
using Logics.Services;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class УслугиWin : Window
    {
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

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

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
                var client = e.AddedItems[0] as Услуга;
                value.Text = client.стоимость.Value.ToString();
            }
        }
    }
}
