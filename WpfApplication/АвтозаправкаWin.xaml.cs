using System.Linq;
using System.Windows;
using Database;
using Logics.Services;
using WpfApplication.Helpers;

namespace WpfApplication
{
    public partial class АвтозаправкаWin : Window
    {
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
                var автозаправка = autoServ.ReadOne(code);
                phone_number.Text = автозаправка.Номер_телефона;
                description.AppendText(автозаправка.Описание);
                address.Text = автозаправка.Общая.First().Адреса;
            }
        }

        private void m92_Click(object sender, RoutedEventArgs e)
        {
            Топливо92 winTool = new Топливо92();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void m95_Click(object sender, RoutedEventArgs e)
        {
            Топливо95 winTool = new Топливо95();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void mdiz_Click(object sender, RoutedEventArgs e)
        {
            Дизельное winTool = new Дизельное();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            КлиентыWin winTool = new КлиентыWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winTool = new MainWindow();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void chek_Click(object sender, RoutedEventArgs e)
        {
            //chek.IsEnabled = false;
            if (Settings.Check.Топливо != null && Settings.Check.Постоянные_клиенты != null)
            {
                ЧекWin winTool = new ЧекWin();
                winTool.Owner = this;
                winTool.Show();
                this.Hide();
                return;
            }
            MessageBox.Show("Выберите топливо и клиента чтобы перейти на чек.");
        }

        private void tov_Click(object sender, RoutedEventArgs e)
        {
            ТоварыWin winTool = new ТоварыWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void usl_Click(object sender, RoutedEventArgs e)
        {
            УслугиWin winTool = new УслугиWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void mFile_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
