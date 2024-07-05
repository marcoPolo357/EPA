using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsLetelica
    {
        // atributi
        private string pRegBr;
        private string pNaziv;

        // property
        public string RegBr
        {
            get
            {
                return pRegBr;
            }
            set
            {
                if (this.pRegBr != value)
                    this.pRegBr = value;
            }
        }

        public string Naziv
        {
            get
            {
                return pNaziv;
            }
            set
            {
                if (this.pNaziv != value)
                    this.pNaziv = value;
            }
        }


        // konstruktor
        public clsLetelica()
        {
            pRegBr = "";
            pNaziv = "";
        }

        // privatne metode

        // javne metode
    }
}
