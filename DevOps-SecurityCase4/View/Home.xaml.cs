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
using System.Windows.Shapes;

namespace DevOps_SecurityCase4.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

      

        private void NewAnime(object sender, RoutedEventArgs e)
        {
            AddAnime addAnime = new AddAnime();
            this.Close();
            addAnime.Show();

        }

        private void myList(object sender, RoutedEventArgs e)
        {
            MyAnime myAnime = new MyAnime();
            this.Close();
            myAnime.Show();
        }
    }
}
