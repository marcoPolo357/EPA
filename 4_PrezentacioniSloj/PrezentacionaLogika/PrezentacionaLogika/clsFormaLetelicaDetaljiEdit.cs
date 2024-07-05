using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class clsFormaLetelicaDetaljiEdit
    {
   // atributi i property
        private string pStringKonekcije;
        private clsLetelicaDB objLetelicaDB;

        private clsLetelica objPreuzetaLetelica;
        private clsLetelica objIzmenjenaLetelica;

        private string pRegBrPreuzeteLetelice;
        private string pNazivPreuzeteLetelice;

        private string pRegBrIzmenjeneLetelice;
        private string pNazivIzmenjeneLetelice;
        
// PROPERTY

        public string RegBrPreuzeteLetelice
        {
            get { return pRegBrPreuzeteLetelice; }
            set { pRegBrPreuzeteLetelice = value; pNazivPreuzeteLetelice = DajNaziv(pRegBrPreuzeteLetelice); }
        }

        public string NazivPreuzeteLetelice
        {
            get { return pNazivPreuzeteLetelice; }
            // OVO NECEMO DA OMOGUCIMO, JER SE RACUNA IZ SIFRE set { pNazivPreuzeteLetelice = value; }
        }

        public string RegBrIzmenjeneLetelice
        {
            get { return pRegBrIzmenjeneLetelice; }
            set { pRegBrIzmenjeneLetelice = value; }
        }


        public string NazivIzmenjeneLetelice
        {
            get { return pNazivIzmenjeneLetelice; }
            set { pNazivIzmenjeneLetelice = value; }
        }


    // konstruktor
        public clsFormaLetelicaDetaljiEdit(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
            objLetelicaDB = new clsLetelicaDB(pStringKonekcije);
        }

        // privatne metode
        private string DajNaziv(string pomRegBrLetelice)
        {
            string pomNaziv ="";
            DataSet dsPodaci = new DataSet();
            pomNaziv = objLetelicaDB.DajNazivPremaRegBr(pomRegBrLetelice); 

            return pomNaziv;
        }

        // javne metode
        public bool ObrisiLetelicu()
        {
            // letelica koja je trenutno u atributima data, TJ. preuzet Reg Br je bitan
            bool uspehBrisanja = false;
            uspehBrisanja = objLetelicaDB.ObrisiLetelicu(pRegBrPreuzeteLetelice);  

            return uspehBrisanja;

        }

        public bool IzmeniLetelicu()
        {
            bool uspehIzmene = false;
            objPreuzetaLetelica = new clsLetelica();
            objIzmenjenaLetelica = new clsLetelica();

            objPreuzetaLetelica.RegBr = pRegBrPreuzeteLetelice;
            objPreuzetaLetelica.Naziv = pNazivPreuzeteLetelice;

            objIzmenjenaLetelica.RegBr = pRegBrIzmenjeneLetelice;
            objIzmenjenaLetelica.Naziv = pNazivIzmenjeneLetelice;

            uspehIzmene = objLetelicaDB.IzmeniLetelicu(objPreuzetaLetelica, objIzmenjenaLetelica);  

            return uspehIzmene;
        }
    }
}
