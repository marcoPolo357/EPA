using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlasePodataka
{
    public class clsOperater
    {
        // atributi
        private string pJMBG;
        private string pPrezime;
        private string pIme;
        private clsLetelica objLetelica;

        // property
        public string JMBG
        {
            get { return pJMBG; }
            set { pJMBG = value; }
        }

        

        public string Prezime
        {
            get { return pPrezime; }
            set { pPrezime = value; }
        }

        

        public string Ime
        {
            get { return pIme; }
            set { pIme = value; }
        }
        

        public clsLetelica Letelica
        {
            get { return objLetelica; }
            set { objLetelica = value; }
        }
    }
}
