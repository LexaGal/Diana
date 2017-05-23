using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Database;
using System.Windows.Shapes;
using Logics.Services;

namespace WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class КлиентWin : Window
    {
        public КлиентWin()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            КлиентыWin winTool = new КлиентыWin();
            //Назначение текущего окна владельцем.
            winTool.Owner = this;
            //Отображение окна, принадлежащего окну-владельцу.
            winTool.Show();
            this.Hide();
             
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var prod = new Постоянные_клиенты()
            {
                ФИО_клиента = name.Text,
                Количество_посещений = int.Parse(amount_of_visitations.Text),
                Номер_карточки_клиента = int.Parse(number.Text)
            };

            var prodServ = ServiceLocator.GetService<Постоянные_клиенты>();
            using (prodServ.Uow.Db = new АвтозаправкиEntities())
            {
                prodServ.Save(prod);
            }
        }
    }
}
