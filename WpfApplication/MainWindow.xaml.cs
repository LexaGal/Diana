﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin(int.Parse(entrance.Text));
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }

        private void entrance_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                KeyConverter KC = new KeyConverter();
                char number = Convert.ToChar(KC.ConvertToString(e.Key));
                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
            }
            catch { }
        }
    }
}
