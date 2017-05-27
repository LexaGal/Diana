using System.Windows;
using Database;
using Logics.Services;namespace WpfApplication
{
    public partial class КлиентWin : Window
    {
        public КлиентWin()
        {
            InitializeComponent();
        }        private void back_Click(object sender, RoutedEventArgs e)
        {
            КлиентыWin winTool = new КлиентыWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }        private void button_Click(object sender, RoutedEventArgs e)
        {
            var prod = new Постоянные_клиенты()
            {
                ФИО_клиента = name.Text,
                Количество_посещений = 0,
                Номер_карточки_клиента = int.Parse(number.Text)
            };            var prodServ = ServiceLocator.GetService<Постоянные_клиенты>();
            using (prodServ.Uow.Db = new АвтозаправкиEntities())
            {
                prodServ.Save(prod);
            }
        }
    }
}
