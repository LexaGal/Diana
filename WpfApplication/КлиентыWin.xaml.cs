﻿using System.Linq;
using System.Windows;
using Database;
//using Database.EFModel;
using Logics.Services;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class КлиентыWin : Window
    {

        //private int _code;
        public КлиентыWin()
        {
            InitializeComponent();
            //this._code = code;
            var autoServ = ServiceLocator.GetService<Постоянные_клиенты>();
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var постоянныеклиенты = autoServ.ReadAll();
                постоянныеклиенты.ToList().ForEach(c => list_of_clients.Items.Add(c));//.ФИО_клиента));

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ЧекWin winTool = new ЧекWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
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

                постоянныеклиенты.ToList().ForEach(c => list_of_clients.Items.Add(c));//.ФИО_клиента));

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

        private void name_of_client_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void list_of_clients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var client = e.AddedItems[0] as Постоянные_клиенты;
                attends_amount.Text = client.Количество_посещений.Value.ToString();
            }
        }
    }
}
