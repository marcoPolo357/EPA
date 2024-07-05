using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaLetelicaTabelaEdit
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsFormaLetelicaTabelaEdit(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaGrid(string filter)
        {
            DataSet dsPodaci = new DataSet();
            clsLetelicaDB objLetelicaDB = new clsLetelicaDB(pStringKonekcije);            
            if (filter.Equals(""))
            {
                dsPodaci = objLetelicaDB.DajSveLetelice(); 
            }
            else
            {
                dsPodaci = objLetelicaDB.DajLetelicuPoNazivu(filter); 
            }
            return dsPodaci;
        }
    }
}
