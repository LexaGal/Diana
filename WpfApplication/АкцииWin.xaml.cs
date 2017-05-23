using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class АкцииWin : Window
    {
        //private int _code;
        public АкцииWin()
        {

            InitializeComponent();
            //this._code = code;
            //var autoServ = ServiceLocator.GetService<Акция>();
            //using (autoServ.Uow.Db = new АвтозаправкиEntities())
            //{
            //    var автозаправка = autoServ.ReadAll().Single(a => a.Код == _code);
            //    phone_number.Text = автозаправка.Номер_телефона;
            //    description.AppendText(автозаправка.Описание);
            //    address.Text = автозаправка.Общая.Адреса;
            //    //автозаправка.Номер_телефона = "12344567";
            //    //var auto = autoServ.Uow.Db.Автозаправка.Find(автозаправка.Код); //Автозаправки //Save(автозаправка, автозаправка.Номер_автозаправки);//.Value);
            //    //autoServ.Uow.Save();

            //}
            //Include(
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

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
