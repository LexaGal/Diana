using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for Window11.xaml
    /// </summary>
    public partial class ТоварWin : Window
    {
         private int _code;
        public ТоварWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //this._code = code;
            //var autoServ = ServiceLocator.GetService<Постоянные_клиенты>();
            //using (autoServ.Uow.Db = new АвтозаправкиEntities())
            //{
            //    var постоянныеклиенты = autoServ.ReadAll();
            //    list_of_clients.Text = постоянныеклиенты.ФИО_клиента;//должен выводится весь список
            //    //description.AppendText(автозаправка.Описание);
            //    name_of_client.Text = постоянныеклиенты.ФИО_клиента;
            //    //автозаправка.Номер_телефона = "12344567";
            //    //var auto = autoServ.Uow.Db.Автозаправка.Find(автозаправка.Код); //Автозаправки //Save(автозаправка, автозаправка.Номер_автозаправки);//.Value);
            //    //autoServ.Uow.Save();

            //}
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ТоварыWin winTool = new ТоварыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }
    }
}
