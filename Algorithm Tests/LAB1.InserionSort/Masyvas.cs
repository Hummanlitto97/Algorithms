﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1.InsertionSort
{
    class Masyvas : DuomenuMasyvas
    {
        char[] duomenys;

        public Masyvas(int kiek, int numeris)
        {
            duomenys = new char[kiek];
            ilgis = kiek;
            Random betkoks = new Random(numeris);
            for (int i = 0; i < kiek; i++)
            {
                duomenys[i] = (char)betkoks.Next(128);
            }
        }

        public override char this[int indeksas]
        {
            get { return duomenys[indeksas]; }
        }

        public override bool Sukeisti(int indeksas, char reiksmePraeito, char dabartineReiksme)
        {
            try
            {
                duomenys[indeksas - 1] = reiksmePraeito;
                duomenys[indeksas] = dabartineReiksme;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
