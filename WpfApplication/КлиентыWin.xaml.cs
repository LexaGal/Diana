using System.Linq;
using System.Windows;
using Database;
using Logics.Services;
using WpfApplication.Helpers;
using System.Windows.Input;
using System;

namespace WpfApplication
{
    public partial class КлиентыWin : Window
    {
        private Постоянные_клиенты client;

        public КлиентыWin()
        {
            InitializeComponent();
            var autoServ = ServiceLocator.GetService<Постоянные_клиенты>();
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var постоянныеклиенты = autoServ.ReadAll();
                постоянныеклиенты.ToList().ForEach(c => list_of_clients.Items.Add(c));
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }       

        private void search_Click(object sender, RoutedEventArgs e)
        {
            var autoServ = ServiceLocator.GetService<Постоянные_клиенты>() as ПостоянныеКлиентыService;
            var n = name_of_client.Text;
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var постоянныеклиенты = autoServ.ReadSome(n);
                list_of_clients.Items.Clear();
                постоянныеклиенты.ToList().ForEach(c => list_of_clients.Items.Add(c));
            }
        }

        private void name_of_client_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        }

        private void list_of_clients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                client = e.AddedItems[0] as Постоянные_клиенты;
                attends_amount.Text = client.Количество_посещений.Value.ToString();
            }
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            КлиентWin winTool = new КлиентWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var prodServ = ServiceLocator.GetService<Постоянные_клиенты>();
            using (prodServ.Uow.Db = new АвтозаправкиEntities())
            {
                var id = (list_of_clients.SelectedItem as Постоянные_клиенты).Номер_карточки_клиента;
                prodServ.Delete(id);
            }
            list_of_clients.Items.Remove(list_of_clients.SelectedItem);
        }

        private void Insert_client_check(object sender, RoutedEventArgs e)
        {
            Settings.Check.Постоянные_клиенты = client;
            if (Settings.Check.Постоянные_клиенты != null)
            {

            }
            MessageBox.Show("Клиент добавлен в чек.");
        }

        private void name_of_client_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                KeyConverter KC = new KeyConverter();
                char number = Convert.ToChar(KC.ConvertToString(e.Key));
                if (!Char.IsLetter(number))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }
    }
}
