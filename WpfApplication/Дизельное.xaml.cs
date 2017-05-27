﻿using Database;
using Logics.Services;
using System.Linq;
using System.Windows;
namespace WpfApplication
{
    public partial class Дизельное : Window
    {
        public Дизельное()
        {
            InitializeComponent();
            var fuelServ = ServiceLocator.GetService<Топливо>();
            using (fuelServ.Uow.Db = new АвтозаправкиEntities())
            {
                value.Text = fuelServ.ReadAll().ToList().Single(f => { return f.название_топлива == "Дизельное"; }).стоимость.ToString();
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            ЧекWin winTool = new ЧекWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
    }
}
