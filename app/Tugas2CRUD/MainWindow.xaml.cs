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
using System.Windows.Navigation;
using System.Windows.Shapes;

using dataMhsDAO;
using MySql.Data.MySqlClient;
using System.Data;


namespace Tugas2CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Mahasiswa
    {
        public string id { get; set; }
        public string Nama { get; set; }
        public string NIM { get; set; }
        public string Angkatan { get; set; }
        public string Prodi { get; set; }
        public string Kelas { get; set; }
        public string Asal_sekolah { get; set; }
        public string Gol_ukt { get; set; }
        public string Ipk { get; set; }
        public string Status { get; set; }
        public string Agama { get; set; }
        public string Alamat { get; set; }
        public string Jk { get; set; }
        public string Tgl_lahir { get; set; }
        public string Nama_ayah { get; set; }
        public string Nama_ibu { get; set; }

    }

    
    
    public partial class MainWindow : Window
    {
        public string stb;
        DAO_FactorySingleton dataset = DAO_FactorySingleton.getObject();
        Mahasiswa mhs = new Mahasiswa();

       
        public MainWindow()
        {
            InitializeComponent();
            
            initDataTb();

           
        }

        public void initDataTb()
        {
            DataMahasiswa dataType = dataset.Mahasiswa("mahasiswa");
            dataGrid1.DataContext = dataType.getDataMhs();
        }

        private void dataInput()
        {
            mhs.Agama = txt_agama.Text;
            mhs.Alamat = txt_alamat.Text;
            mhs.Nama = txt_nama.Text;
            mhs.NIM = txt_nama.Text;
            mhs.Kelas = txt_kelas.Text;
            mhs.Angkatan = txt_akt.Text;
            var item = (ComboBoxItem)comboProdi.SelectedValue;
            mhs.Prodi = (string)item.Content;
            mhs.Asal_sekolah = txt_sekolah.Text;
            mhs.Ipk = txt_ipk.Text;
            mhs.Gol_ukt = txt_ukt.Text;
            mhs.Status = (bool)rad_status.IsChecked ? rad_status.Content.ToString() : rad_status1.Content.ToString();
            string tgl = datepick_tgl_lahir.ToString();
            mhs.Tgl_lahir = tgl.Substring(0, 10);
            mhs.Nama_ayah = txt_ayah.Text;
            mhs.Nama_ibu = txt_ibu.Text;
            var item_jk = (ComboBoxItem)comboJk.SelectedValue;
            mhs.Jk = (string) item_jk.Content;
        }

        private void resetData()
        {
            txt_nama.Text="";
            txt_nim.Text = "";
            txt_kelas.Text = "";
            txt_akt.Text = "";
            txt_sekolah.Text = "";
            rad_status.IsChecked = false;
            rad_status1.IsChecked = false;
            txt_ayah.Text = "";
            txt_ibu.Text = "";
            datepick_tgl_lahir.Text="";
            comboProdi.Text = "--- Pilih Prodi ---";
            comboJk.Text = "--- Jenis Kelamin ---";
            txt_alamat.Text = "";
            txt_agama.Text = "";
            txt_ipk.Text = "";
            txt_ukt.Text = "";
;        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (txt_nama.Text.Length == 0 || txt_nim.Text.Length == 0 || txt_kelas.Text.Length == 0 || txt_akt.Text.Length == 0 || txt_ukt.Text.Length == 0 || txt_sekolah.Text.Length == 0 || txt_alamat.Text.Length == 0 || txt_ipk.Text.Length == 0 || txt_agama.Text.Length == 0 || txt_ayah.Text.Length == 0 || txt_ibu.Text.Length == 0 || datepick_tgl_lahir.Text.Length == 0)
            {
                MessageBox.Show("HARAP LENGKAPI DATA ANDA", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            } 
            else
            {
                 dataInput();
                DataMahasiswa dataType = dataset.Mahasiswa("mahasiswa");
                dataType.InsertDataMhs(mhs.id, mhs.Nama, mhs.NIM, mhs.Angkatan, mhs.Prodi, mhs.Kelas, mhs.Asal_sekolah, mhs.Gol_ukt, mhs.Ipk, mhs.Status, mhs.Agama, mhs.Alamat, mhs.Jk, mhs.Tgl_lahir, mhs.Nama_ayah, mhs.Nama_ibu);
                 initDataTb();
                 resetData();
                    MessageBox.Show("Data Berhasil Tersimpan", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (txt_nama.Text.Length == 0 || txt_nim.Text.Length == 0 || txt_kelas.Text.Length == 0 || txt_akt.Text.Length == 0 || txt_ukt.Text.Length == 0 || txt_sekolah.Text.Length == 0 || txt_alamat.Text.Length == 0 || txt_ipk.Text.Length == 0 || txt_agama.Text.Length == 0 || txt_ayah.Text.Length == 0 || txt_ibu.Text.Length == 0 || datepick_tgl_lahir.Text.Length == 0)
            {
                MessageBox.Show("HARAP LENGKAPI DATA ANDA", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                dataInput();
                DataMahasiswa dataType = dataset.Mahasiswa("mahasiswa");
                dataType.UpdateDataMhs(mhs.id, mhs.Nama, mhs.NIM, mhs.Angkatan, mhs.Prodi, mhs.Kelas, mhs.Asal_sekolah, mhs.Gol_ukt, mhs.Ipk, mhs.Status, mhs.Agama, mhs.Alamat, mhs.Jk, mhs.Tgl_lahir, mhs.Nama_ayah, mhs.Nama_ibu, txt_nim.Text);
                initDataTb();
                resetData();
                MessageBox.Show("Data berhail diupdate");
            }
            
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Are you sure you want to exit off the application", "Are you sure?", MessageBoxButton.YesNo); //Gets users input by showing the message box

            if (result == MessageBoxResult.Yes) //Creates the yes function
            {
                DataMahasiswa datatype = dataset.Mahasiswa("mahasiswa");
                datatype.DeleteDataMhs(txt_nim.Text);
                initDataTb();
                resetData();
            
            }
            

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            resetData();
        }

        private void data_doubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView drv = (DataRowView)dataGrid1.SelectedItem;
            string nama = drv["nama"].ToString();
            string nim = drv["nim"].ToString();
            string angkatan = drv["angkatan"].ToString();
            string prodi = drv["prodi"].ToString();
            string kelas= drv["kelas"].ToString();
            string asal_sekolah = drv["asal_sekolah"].ToString();
            string gol_ukt= drv["gol_ukt"].ToString();
            string ipk = drv["ipk"].ToString();
            string status= drv["status"].ToString();
            string agama = drv["agama"].ToString();
            string alamat= drv["alamat"].ToString();
            string jk= drv["jk"].ToString();
            string tgl_lahir= drv["tgl_lahir"].ToString();
            string ayah= drv["ayah"].ToString();
            string ibu= drv["ibu"].ToString();

            

            txt_nama.Text = nama;
            txt_nim.Text = nim;
            txt_akt.Text = angkatan;
            comboProdi.Text = prodi;
            txt_kelas.Text = kelas;
            txt_sekolah.Text = asal_sekolah;
            txt_ukt.Text = gol_ukt;
            txt_ipk.Text = ipk;
            comboJk.Text = jk;
            txt_agama.Text = agama;
            txt_alamat.Text = alamat;
            datepick_tgl_lahir.Text = tgl_lahir;
            txt_ayah.Text = ayah;
            txt_ibu.Text = ibu;
            comboJk.Text = jk;

            if(rad_status.Content.ToString() == status)
            {
                rad_status.IsChecked = true;

            }
            if(rad_status1.Content.ToString() == status)
            {
                rad_status1.IsChecked = true;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            resetData();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            DataMahasiswa datatype = dataset.Mahasiswa("mahasiswa");
            dataGrid1.DataContext = datatype.cariData(txtCari.Text); ;
            

        }

        private void showNilai(object sender, RoutedEventArgs e)
        {


            DataRowView drv = (DataRowView)dataGrid1.SelectedItem;
            stb = drv["nim"].ToString();

            dll nillai = new dll(stb);
            nillai.Show();
        }
    }
}
