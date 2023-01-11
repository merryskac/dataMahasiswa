using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace dataMhsDAO
{
    public class DAO_FactorySingleton
    {
        private int value;
        private int jmlObjek;
        private static DAO_FactorySingleton dao = new DAO_FactorySingleton();

        private DAO_FactorySingleton()
        {
            Console.WriteLine("Objek dibuat...");
            jmlObjek++;
            Console.WriteLine("jumlah = {0}", jmlObjek);

        }


        public static DAO_FactorySingleton getObject()
        {
            return dao;
        }

        public DataMahasiswa Mahasiswa(String dataCrud)
        {
            if (dataCrud == null)
            {
                return null;
            }
            else if (dataCrud.ToLower() == "mahasiswa")
            {
                return new Mahasiswa();
            }
            else if (dataCrud.ToLower() == "nilai")
            {
                return new Nilai();
            }
            
            else
            {
                return null;
            }

        }

        public void setValue(int a)
        {
            this.value = a;
        }

        public string getValue()
        {
            string a = "jumlah = "+ jmlObjek.ToString()+", Nilai= "+value.ToString();
            return a;
        }
    }

}