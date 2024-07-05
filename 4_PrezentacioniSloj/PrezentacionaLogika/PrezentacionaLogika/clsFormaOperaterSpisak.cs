using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaOperaterSpisak
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaOperaterSpisak(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsOperaterDB objNastavnikDB = new clsOperaterDB(pStringKonekcije);
            if (filter.Equals(""))
            {
                dsPodaci = objNastavnikDB.DajSveOperatere(); 
            }
            else
            {
                dsPodaci = objNastavnikDB.DajOperateraPoPrezimenu(filter);
            }
            return dsPodaci;
        }

    }
}
