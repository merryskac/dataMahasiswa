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

namespace Tugas2CRUD
{
    /// <summary>
    /// Interaction logic for HalamanAwal.xaml
    /// </summary>
    public partial class HalamanAwal : Window
    {
        public HalamanAwal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow halaman_awal = new MainWindow();
            halaman_awal.Show();
        }
    }
}
