﻿using System;
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
using System.Windows.Shapes;

namespace DevOps_SecurityCase4.View
{
    /// <summary>
    /// Interaction logic for AddAnime.xaml
    /// </summary>
    public partial class AddAnime : Window
    {
        public AddAnime()
        {
            InitializeComponent();
        }


        private void Home(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }
    }
}
