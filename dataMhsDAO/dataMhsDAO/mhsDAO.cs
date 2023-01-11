using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace dataMhsDAO
{

    public abstract class DataMahasiswa
    {
        public virtual DataSet getDataMhs()
        {
            return null;
        }
        public virtual DataSet getDataNilai(String Stb) { return null; }
        public virtual DataSet cariData(string word) { return null; }
        public virtual bool InsertDataMhs(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu) { return false; }
        public virtual bool InsertNilai(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas) { return false; }
        public virtual bool DeleteDataMhs(string nim) { return false; }
        public virtual bool deleteNilai(string nim, string kode) { return false; }
        public virtual bool UpdateDataMhs(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu, string nim) { return false; }
        public virtual bool UpdateNilai(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas) { return false; }

    }

    internal class mhsDAO
    {
        private MySqlCommand command = null;
        MySqlConnection conn = new MySqlConnection();
        string config = "Server = localhost; Port = 3306;  UID = root; PWD=; Database = pendataan_mhs";


        public mhsDAO()
        {
            conn.ConnectionString = config;
        }

        private DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM  mahasiswa";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(ds, "mahasiswa");
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e, "error");
            }
            return ds;
        }

        private DataSet getDataNilai(string stb)
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM mata_kuliah inner join nilai on mata_kuliah.kode_mk = nilai.kode_mk where nilai.nim = '" + stb + "'";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(ds, "mata_kuliah");
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e, "error");
            }
            return ds;

        }

        private DataSet cariData(string word)
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM mahasiswa WHERE nama like '%" + word + "%' OR nim like '%" + word + "%'";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(ds, "mahasiswa");
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when get data: " + e, "error");
            }
            return ds;
        }

        private bool InsertData(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu)
        {

            Boolean status = false;
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "INSERT INTO mahasiswa VALUES('" + id + "','" + Nama + "','" + NIM + "','" + Angkatan + "','" + Prodi + "','" + Kelas + "','" + Asal_sekolah + "','" + Gol_ukt + "','" + Ipk + "','" + Status + "','" + Agama + "','" + Alamat + "','" + Jk + "','" + Tgl_lahir + "','" + Nama_ayah + "','" + Nama_ibu + "')";
                command.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when insert data: " + e.Message);
            }
            return status;
        }

        private bool InsertNilai(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas)
        {
            bool status = false;
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "INSERT IGNORE INTO mata_kuliah VALUES('" + kode + "','" + mk + "','" + dosen + "'); INSERT IGNORE INTO nilai VALUES ('" + nim + "','" + kode + "','" + nilai_tugas + "','" + nilai_uts + "','" + nilai_uas + "');";
                command.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return status;

        }
        private bool DeleteData(string nim)
        {
            Boolean status = false;
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "DELETE FROM mahasiswa WHERE `nim` ='" + nim + "'";
                command.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when delete data: " + e.Message);
            }
            return status;
        }
        private bool deleteNilai(string nim, string kode)
        {
            bool status = false;
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "DELETE FROM nilai WHERE nim='" + nim + "' AND kode_mk='" + kode + "'";
                command.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }
        private bool UpdateData(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu, string nim)
        {
            Boolean status = false;
            try
            {

                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "UPDATE mahasiswa SET nama='" + Nama + "' ,angkatan='" + Angkatan + "' ,prodi='" + Prodi + "' ,kelas= '" + Kelas + "',asal_sekolah='" + Asal_sekolah + "' ,gol_ukt= '" + Gol_ukt + "',ipk='" + Ipk + "' ,status='" + Status + "' ,agama='" + Agama + "' ,alamat= '" + Alamat + "' ,jk= '" + Jk + "' ,tgl_lahir= '" + Tgl_lahir + "' ,ayah= '" + Nama_ayah + "',ibu='" + Nama_ibu + "' WHERE nim='" + nim + "'";
                command.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection Problems when update data: " + e.Message);
            }
            return status;
        }
        private bool UpdateNilai(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas)
        {
            bool status = false;
            try
            {
                conn.Close();
                conn.Open();
                command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "Update nilai SET nilai_tugas='" + nilai_tugas + "',nilai_uts='" + nilai_uts + "',nilai_uas='" + nilai_uas + "' WHERE nim='" + nim + "' AND kode_mk='" + kode + "'";
                command.ExecuteNonQuery();
                status = true;
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return status;
        }
        public DataSet getMahasiswa()
        {
            return getData();
        }
        public DataSet getGrade(string stb)
        {
            return getDataNilai(stb);
        }
        public DataSet pencarian(string word)
        {
            return cariData(word);
        }
        public bool insertMahasiswa(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu)
        {
            return InsertData(id, Nama, NIM, Angkatan, Prodi, Kelas, Asal_sekolah, Gol_ukt, Ipk, Status, Agama, Alamat, Jk, Tgl_lahir, Nama_ayah, Nama_ibu);
        }
        public bool insertGrade(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas)
        {
            return InsertNilai(nim, kode, mk, dosen, nilai_tugas, nilai_uts, nilai_uas);
        }
        public bool deleteMahasiswa(string nim)
        {
            return DeleteData(nim);
        }
        public bool deleteGrade(string nim, string kode_mk)
        {
            return deleteNilai(nim, kode_mk);
        }
        public bool updateMahasiswa(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu, string nim)
        {
            return UpdateData(id, Nama, NIM, Angkatan, Prodi, Kelas, Asal_sekolah, Gol_ukt, Ipk, Status, Agama, Alamat, Jk, Tgl_lahir, Nama_ayah, Nama_ibu, nim);
        }
        public bool updateGrade(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas)
        {
            return UpdateNilai(nim, kode, mk, dosen, nilai_tugas, nilai_uts, nilai_uas);
        }
    }
        class Mahasiswa : DataMahasiswa
        {
            mhsDAO dao = new mhsDAO();
            public override DataSet getDataMhs()
            {

                return dao.getMahasiswa();
            }

            public override bool InsertDataMhs(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu)
            {
                return dao.insertMahasiswa(id, Nama, NIM, Angkatan, Prodi, Kelas, Asal_sekolah, Gol_ukt, Ipk, Status, Agama, Alamat, Jk, Tgl_lahir, Nama_ayah, Nama_ibu);
            }

            public override bool UpdateDataMhs(string id, string Nama, string NIM, string Angkatan, string Prodi, string Kelas, string Asal_sekolah, string Gol_ukt, string Ipk, string Status, string Agama, string Alamat, string Jk, string Tgl_lahir, string Nama_ayah, string Nama_ibu, string nim)
            {
                return dao.updateMahasiswa(id, Nama, NIM, Angkatan, Prodi, Kelas, Asal_sekolah, Gol_ukt, Ipk, Status, Agama, Alamat, Jk, Tgl_lahir, Nama_ayah, Nama_ibu, nim);
            }

            public override bool DeleteDataMhs(string nim)
            {
                return dao.deleteMahasiswa(nim);
            }

            public override DataSet cariData(string word)
            {
                return dao.pencarian(word);
            }
    }

        class Nilai : DataMahasiswa
        {
            mhsDAO dao = new mhsDAO();

            public override DataSet getDataNilai(string Stb)
            {
                return dao.getGrade(Stb);
            }

            public override bool InsertNilai(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas)
            {
                return dao.insertGrade(nim, kode, mk, dosen, nilai_tugas, nilai_uts, nilai_uas);
            }

            public override bool UpdateNilai(string nim, string kode, string mk, string dosen, string nilai_tugas, string nilai_uts, string nilai_uas)
            {
                return dao.updateGrade(nim, kode, mk, dosen, nilai_tugas, nilai_uts, nilai_uas);
            }

            public override bool deleteNilai(string nim, string kode)
            {
                return dao.deleteGrade(nim, kode);
            }


    }
}
