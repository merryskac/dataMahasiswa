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
using dataMhsDAO;
using System.Data;

namespace Tugas2CRUD
{
    /// <summary>
    /// Interaction logic for dll.xaml
    /// </summary>
    ///
    class Mata_kuliah
    {
        public string Kode_mk { get; set; }
        public string Nama_mk { get; set; }
        public string Dosen { get; set; }
    }

    class Nilai
    {
        public string nim { get; set; }
        public string kode_mk { get; set; }
        public string nilai_tugas { get; set; }
        public string nilai_uts { get; set; }
        public string nilai_uas { get; set; }
    }

    public partial class dll : Window
    {
        DAO_FactorySingleton dataset = DAO_FactorySingleton.getObject();
        DAO_FactorySingleton data2 = DAO_FactorySingleton.getObject();        

        Nilai nilai = new Nilai();
        Mata_kuliah mk = new Mata_kuliah();
        
            public dll(string stb)
        {
            InitializeComponent();
            initNilai(stb);
            test.Content = stb;
             
        }

        private void initNilai(string stb)
        {
            
            DataMahasiswa datatype = dataset.Mahasiswa("nilai");
            grid_nilai.DataContext = datatype.getDataNilai(stb);
        }

        private void get_Data()
        {
            nilai.kode_mk = txt_kodemk.Text;
            mk.Nama_mk = txt_mk.Text;
            mk.Dosen = txt_dosen.Text;
            nilai.nilai_tugas = txt_tugas.Text;
            nilai.nilai_uts = txt_uts.Text;
            nilai.nilai_uas = txt_uas.Text;
            nilai.nim = test.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            get_Data();
            DataMahasiswa datatype = dataset.Mahasiswa("nilai");
            int rowCountbef = grid_nilai.Items.Count;
            datatype.InsertNilai(nilai.nim, nilai.kode_mk, mk.Nama_mk, mk.Dosen, nilai.nilai_tugas, nilai.nilai_uts, nilai.nilai_uas);
            initNilai(nilai.nim);

            int rowCountAft = grid_nilai.Items.Count;
            if (rowCountbef == rowCountAft)
            {
                MessageBox.Show("Data sudah ada");
            }
        }

        private void nilai_doubleClick(object sender, MouseButtonEventArgs e)
        {
            btn_tambah.IsEnabled = false;
            DataRowView dr = (DataRowView) grid_nilai.SelectedItem;

            txt_kodemk.Text = dr["kode_mk"].ToString();
            txt_dosen.Text = dr["dosen"].ToString();
            txt_mk.Text = dr["nama_mk"].ToString();
            txt_tugas.Text = dr["nilai_tugas"].ToString();
            txt_uts.Text = dr["nilai_uts"].ToString();
            txt_uas.Text = dr["nilai_uas"].ToString();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataMahasiswa datatype = dataset.Mahasiswa("nilai");
            get_Data();
            datatype.UpdateNilai(nilai.nim, nilai.kode_mk, mk.Nama_mk, mk.Dosen, nilai.nilai_tugas, nilai.nilai_uts, nilai.nilai_uas);
            initNilai(nilai.nim);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn_tambah.IsEnabled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataMahasiswa datatype = dataset.Mahasiswa("nilai");
            get_Data();
            datatype.deleteNilai(nilai.nim, nilai.kode_mk);
            initNilai(nilai.nim);
        }
    }
}
