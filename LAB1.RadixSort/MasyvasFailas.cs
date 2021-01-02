using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1.RadixSort
{
    class MasyvasFailas : DuomenuMasyvas
    {
        char[] duomenys;
        public FileStream rs { get; set; }

        public MasyvasFailas(string failas, int kiek, int numeris)
        {
            duomenys = new char[kiek];
            ilgis = kiek;
            Random betkoks = new Random(numeris);
            for (int i = 0; i < kiek; i++)
            {
                duomenys[i] = (char)betkoks.Next(128);
            }

            try
            {
                using (BinaryWriter rasytojas = new BinaryWriter(File.Open(failas, FileMode.Create)))
                {
                    for (int i = 0; i < ilgis; i++)
                    {
                        rasytojas.Write(duomenys[i]);
                    }
                }
            }
            catch (IOException klaida)
            {
                Console.WriteLine(klaida.ToString());
            }
        }

        public override char this[int indeksas]
        {
            get
            {
                Byte[] duomenys = new Byte[2];
                rs.Seek(indeksas, SeekOrigin.Begin);
                rs.Read(duomenys, 0, 1);
                return BitConverter.ToChar(duomenys, 0);
            }
        }

        public override bool Sukeisti(int indeksas, char dabartineReiksme)
        {
            Byte[] duomenys = new Byte[2];
            BitConverter.GetBytes(dabartineReiksme).CopyTo(duomenys, 0);
            rs.Seek(indeksas, SeekOrigin.Begin);
            rs.Write(duomenys, 0, 1);
            return true;
        }
    }
}
