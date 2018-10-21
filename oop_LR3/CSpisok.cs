using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2OOP
{
    class CSpisok
    {
        private int kw;
        private CPerson[] MasPerson = new CPerson[100];
        private string nameFile;

        public CSpisok()
        {
            int i = 0;
            nameFile = "temp.txt";
            
            StreamReader reader = new StreamReader(nameFile, Encoding.GetEncoding(1251));
            while (!reader.EndOfStream)
            {
                i = i + 1;
                MasPerson[i] = new CPerson(reader);
            }
            
             kw = i;
             reader.Close();
        }
        public CSpisok(string s)
        {
            int i = 0;
            s = s + ".txt";
            nameFile = s;
            StreamReader reader;
            try
            {
                reader = new StreamReader(nameFile, Encoding.GetEncoding(1251));
                while (!reader.EndOfStream)
                {
                    i = i + 1;
                    MasPerson[i] = new CPerson(reader);
                }
                kw = i;
                reader.Close();
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
                       
        }

        public CPerson GetData(int i)
        {
            return MasPerson[i];
        }
        public string GetStringData(int i)
        {
            return MasPerson[i].FullData;
        }
        public int Kw_pers
        {
            get => kw ;
        }
        public void AddPerson(CPerson value)
        {
            kw++;
            MasPerson[kw] = value;
        }
        public void DeletePerson(int id)
        {
            CPerson[] nArray = new CPerson[MasPerson.Length - 1];
            //var cIndex = 0;
            kw--;
            for (int i = 1; i < id; i++)
            {
                nArray[i] = MasPerson[i];
            }

            for (int i = id + 1; i < nArray.Length; i++)
            {
                nArray[i] = MasPerson[i];
            }
            for (int i = 1; i <= kw; i++)
            {
                MasPerson[i] = nArray[i];
            }
            
        }
        ~CSpisok()
        {
            FileStream file1 = new FileStream(nameFile, FileMode.Create);
            StreamWriter f = new StreamWriter(file1,Encoding.GetEncoding(1251));
            for (int i = 1; i <= kw; i++)
            {
                MasPerson[i].WriteData(f);
            }
            f.Close();
        }

    }
}
