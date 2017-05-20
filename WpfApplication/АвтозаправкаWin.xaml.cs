using System.Linq;
using System.Windows;
using Database;
//using Database.EFModel;
using Logics.Services;
using WpfApplication.Helpers;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class АвтозаправкаWin : Window
    {
        //private int _code;

        public АвтозаправкаWin()
        {
            InitializeComponent();
            FillFields(Settings.AutoCode);
        }

        public АвтозаправкаWin(int code) : base()
        {
            InitializeComponent();
            Settings.AutoCode = code;
            FillFields(code);
        }

        private void FillFields(int code)
        {
            var autoServ = ServiceLocator.GetService<Автозаправка>();
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var автозаправка = autoServ.ReadOne(code); //ReadAll().Single(a => a.Код == code);
                phone_number.Text = автозаправка.Номер_телефона;
                description.AppendText(автозаправка.Описание);
                address.Text = автозаправка.Общая.First().Адреса;
                //автозаправка.Номер_телефона = "12344567";
                //var auto = autoServ.Uow.Db.Автозаправка.Find(автозаправка.Код); //Автозаправки //Save(автозаправка, автозаправка.Номер_автозаправки);//.Value);
                //autoServ.Uow.Save();

            }
            //Include(
        }

        private void m92_Click(object sender, RoutedEventArgs e)
        {
            Топливо92 winTool = new Топливо92();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void m95_Click(object sender, RoutedEventArgs e)
        {
            Топливо95 winTool = new Топливо95();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void mdiz_Click(object sender, RoutedEventArgs e)
        {
            Дизельное winTool = new Дизельное();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            КлиентыWin winTool = new КлиентыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }



        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winTool = new MainWindow();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void chek_Click(object sender, RoutedEventArgs e)
        {
            ЧекWin winTool = new ЧекWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void tov_Click(object sender, RoutedEventArgs e)
        {
            ТоварыWin winTool = new ТоварыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void usl_Click(object sender, RoutedEventArgs e)
        {
            УслугиWin winTool = new УслугиWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }

        private void mFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            АкцииWin winTool = new АкцииWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
        }
    }
}
