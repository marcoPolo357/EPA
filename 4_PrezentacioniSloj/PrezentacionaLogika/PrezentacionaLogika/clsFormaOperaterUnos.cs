using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;
using KlasePodataka;
using PoslovnaLogika;

namespace PrezentacionaLogika
{
    public class clsFormaOperaterUnos
    {
        // atributi
        private string pStringKonekcije;
        private string pJMBG;
        private string pPrezime;
        private string pIme;
        private string pNazivLetelice;

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
        
        public string NazivLetelice
        {
            get { return pNazivLetelice; }
            set { pNazivLetelice = value; }
        }
        
        // konstruktor
        public clsFormaOperaterUnos(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // private metode

        // public metode
        public DataSet DajPodatkeZaCombo()
        {
            DataSet dsPodaci = new DataSet();
            clsLetelicaDB objLetelicaDB = new clsLetelicaDB(pStringKonekcije);

            dsPodaci = objLetelicaDB.DajSveLetelice();

            return dsPodaci;
        }

        public bool DaLiJeSvePopunjeno()
        {
            bool SvePopunjeno = false;

            // PITANJE U NEGATIVNOM KONTEKSTU if ((txbJMBG.Text.Length == 0) || (txbPrezime.Text.Length == 0) || (txbIme.Text.Length == 0) || (ddlZvanje.Text.Length == 0) || (ddlZvanje.Text == "Izaberite..."))

            // PRERADA KODA - IF (da li nesto jeste)

            if ((pJMBG.Length > 0) && (pPrezime.Length > 0) && (pIme.Length > 0) && (pNazivLetelice.Length > 0) && (!pNazivLetelice.Equals("Izaberite...")))
            {
                SvePopunjeno = true;
            }
            else
            {
                SvePopunjeno = false;
            }

            return SvePopunjeno;
        }


        public bool DaLiJeJedinstvenZapis()
        {
            bool JedinstvenZapis = false;
            DataSet dsPodaci = new DataSet();
            clsOperaterDB objOperaterDB = new clsOperaterDB(pStringKonekcije);
            dsPodaci = objOperaterDB.DajOperateraPoJMBG(pJMBG);
            
            if (dsPodaci.Tables[0].Rows.Count == 0)
            {
                JedinstvenZapis = true;
            }
            else
            {
                JedinstvenZapis = false;
            }

            return JedinstvenZapis;

        }

        public bool SnimiPodatke()
        {
            bool uspehSnimanja=false;

            clsOperaterDB objOperaterDB = new clsOperaterDB(pStringKonekcije);

            clsOperater objNoviOperater = new clsOperater();
            objNoviOperater.JMBG = (pJMBG);
            objNoviOperater.Prezime = pPrezime;
            objNoviOperater.Ime = pIme;

            clsLetelica objLetelica = new clsLetelica();

            clsLetelicaDB objLetelicaDB = new clsLetelicaDB(pStringKonekcije);
            objLetelica.RegBr = objLetelicaDB.DajRegBrPoNazivu(pNazivLetelice); 
            objLetelica.Naziv = pNazivLetelice; 

            objNoviOperater.Letelica  = objLetelica; 
            
            uspehSnimanja = objOperaterDB.SnimiNovogOperatera(objNoviOperater); 


            return uspehSnimanja;
        }

        public bool DaLiSuPodaciUskladjeniSaPoslovnimPravilima()
        {
            // POSLOVNO PRAVILO:
            // Veličina letelice utiče na broj operatera koji mogu da je opslužuju
            //Teška letelica = 3 operatera
            //Srednja letelica = 2 operatera
            //Laka letelica = 1 operater
            bool UskladjeniPodaci = false;

            clsPoslovnaPravila objPoslovnaPravila = new clsPoslovnaPravila(pStringKonekcije);
            
            //izracunavanje ID zvanja
            clsLetelicaDB objLetelicaDB = new clsLetelicaDB(pStringKonekcije);
            string RegBrLetelice = objLetelicaDB.DajRegBrPoNazivu(pNazivLetelice); 
                       
            UskladjeniPodaci = objPoslovnaPravila.DaLiImaMestaZaNovogOperatera(RegBrLetelice);

            return UskladjeniPodaci;
        }
    }
}
