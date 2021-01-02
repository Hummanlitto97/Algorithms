using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1.InsertionSort
{
    class InsertionSortTestas
    {
        static void Main(string[] args)
        {
            int numeris = (int)DateTime.Now.Ticks & 0x0000FFFF;
            TestasMasyvasSarasas(numeris);
            TestasFailuose(numeris);
        }

        public static void TestasMasyvasSarasas(int numeris)
        {
            int dydis = 12;
            Masyvas masyvas = new Masyvas(dydis, numeris);
            Console.WriteLine("\n Masyvas \n");
            masyvas.Spausdinti(dydis);
            Console.WriteLine("\n Masyvas (Rikiuotas) \n");
            InsertionSort(masyvas);
            masyvas.Spausdinti(dydis);
            Sarasas sarasas = new Sarasas(dydis, numeris);
            Console.WriteLine("\n Sarasas nuo priekio \n");
            sarasas.Spausdinti(dydis);
            Console.WriteLine("\n Sarasas nuo galo \n");
            sarasas.SpausdintiNuoGalo(dydis);
            Console.WriteLine("\n Sarasas nuo priekio (Rikiuotas) \n");
            InsertionSort(sarasas);
            sarasas.Spausdinti(dydis);
            Console.WriteLine("\n Sarasas nuo galo (Rikiuotas)\n");
            sarasas.SpausdintiNuoGalo(dydis);
        }

        public static void InsertionSort(DuomenuMasyvas daiktai)
        { 
            for (int i = 1; i < daiktai.Ilgis; i++)
            { 
                char raktas = daiktai[i];
                int j = i - 1;
                while(j >= 0 && daiktai[j] > raktas)
                {
                    daiktai.Sukeisti(j+1, raktas, daiktai[j]);
                    j = j - 1;
                }
            }
        }

        public static void InsertionSort(DuomenuSarasas daiktai)
        {
            for (int i = 1; i < daiktai.Ilgis; i++)
            {
                char raktas = daiktai.Rasti(i);
                int j = i - 1;
                while (j >= 0 && daiktai.Kairen() > raktas)
                {
                    daiktai.Sukeisti(daiktai.Esamas(), raktas);
                    j = j - 1;
                }
            }
        }
        
        public static void TestasFailuose(int numeris)
        {
            int kiekis = 12;
            string failas;
            failas = @"DuomenuMasyvasIn.dat";
            MasyvasFailas DuomenuMasyvasIn = new MasyvasFailas(failas, kiekis, numeris);
            using (DuomenuMasyvasIn.rs = new FileStream(failas, FileMode.Open,
            FileAccess.ReadWrite))
            {
                //Masyvas
                Console.WriteLine("\n Failo Masyvas \n");
                DuomenuMasyvasIn.Spausdinti(kiekis);
                Console.WriteLine("\n Rikiuotas Failo Masyvas \n");
                InsertionSort(DuomenuMasyvasIn);
                DuomenuMasyvasIn.Spausdinti(kiekis);
            }

            failas = @"DuomenuSarasasIn.dat";
            SarasasFailas DuomenuSarasasIn = new SarasasFailas(failas, kiekis, numeris);
            using (DuomenuSarasasIn.rs = new FileStream(failas, FileMode.Open,
            FileAccess.ReadWrite))
            {
                //Sarasas
                Console.WriteLine("\n Failo Sarasas nuo priekio \n");
                DuomenuSarasasIn.Spausdinti(kiekis);
                Console.WriteLine("\n Failo sarasas nuo galo \n");
                DuomenuSarasasIn.SpausdintiNuoGalo(kiekis);

                Console.WriteLine("\n Failo Sarasas nuo priekio (Rikiuotas) \n");
                InsertionSort(DuomenuSarasasIn);
                DuomenuSarasasIn.Spausdinti(kiekis);
                Console.WriteLine("\n Failo sarasas nuo galo (Rikiuotas) \n");
                DuomenuSarasasIn.SpausdintiNuoGalo(kiekis);
            }
        }
    }

    abstract class DuomenuMasyvas
    {
        protected int ilgis;
        public int Ilgis { get { return ilgis; } }
        public abstract char this[int indeksas] { get; }
        public abstract bool Sukeisti(int indeksas, char reiksmePraeito, char dabartineReiksme);
        public void Spausdinti(int kiekis)
        {
            for (int i = 0; i < kiekis; i++)
            {
                Console.Write("Zenklas: {0,-10} Kodas: {1}\n", this[i], (int)this[i]);
            }
            Console.WriteLine();
        }
    }

    abstract class DuomenuSarasas
    {
        protected int ilgis;
        public int Ilgis { get { return ilgis; } }
        public abstract char Pradzia();
        public abstract char Pabaiga();
        public abstract char Esamas();
        public abstract bool Salyga();
        public abstract char Desinen();
        public abstract char Kairen();
        public abstract bool Sukeisti(char praeitaReiksme, char dabartineReiksme);
        public abstract char Rasti(int indeksas);
        public void Spausdinti(int kiekis)
        {
            Console.Write("Zenklas: {0,-10} Kodas: {1} \n", Pradzia(), (int)Esamas());
            for (int i = 0;i < kiekis - 1; i++)
            {
                Console.Write("Zenklas: {0,-10} Kodas: {1} \n", Desinen(), (int)Esamas());
            }
            Console.WriteLine();
        }

        public void SpausdintiNuoGalo(int kiekis)
        {
            Console.Write("Zenklas: {0,-10} Kodas: {1} \n", Pabaiga(), (int)Esamas());
            for (int i = 0; i < kiekis - 1; i++)
            {
                Console.Write("Zenklas: {0,-10} Kodas: {1} \n", Kairen(), (int)Esamas());
            }
            Console.WriteLine();
        }
    }

}
