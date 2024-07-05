using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;
using KlaseMapiranja;

namespace PoslovnaLogika
{
    public class clsPoslovnaPravila
    {
        // TREBALO BI DA SE PRERADI IZ 3 KLASE:
        // Sistematizacija radnih mesta - izdvaja ogranicenje
        // Opterecenje - stanje u BP povodom broja operatera
        // Zaposljavanje - proverava i uporedjuje podatke iz sistematizacije i opterecenja
        
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsPoslovnaPravila(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }

        // privatne metode

        // public metode
        public bool DaLiImaMestaZaNovogOperatera(string IdLeteliceIzBazePodataka)
        {
            // POSLOVNO PRAVILO:
            // Veličina letelice utiče na broj operatera koji mogu da je opslužuju
            //Teška letelica = 3 operatera
            //Srednja letelica = 2 operatera
            //Laka letelica = 1 operater

            bool imaMesta = false;

            // ################################################################
            // 1. IZRACUNAVANJE TRENUTNOG BROJA OPERATERA U BAZI PODATAKA
            // 
            int UkupnoOperatera = 0;
            clsOperaterDB objOperaterDB = new clsOperaterDB(pStringKonekcije);
            UkupnoOperatera = objOperaterDB.DajUkupnoOperateraZaLetelicu(IdLeteliceIzBazePodataka);

            // ################################################################
            // 2. MAPIRANJE SLOJEVA - uskladjivanje Reg Br Letelice iz raznih delova programa
            // Web servis ima h - heavy (teška letelica), baza podataka ima reg br - H - C130 Globemaster
            string RegBrLeteliceWS = "";
            clsMaper objMaper = new clsMaper(pStringKonekcije);
            RegBrLeteliceWS = objMaper.DajRegBrLeteliceZaWebServis(IdLeteliceIzBazePodataka);

            // ################################################################
            // 3. IZDVAJANJE MAX BROJA OPERATERA ZA ODGOVARAJUĆU LETELICU
            WSOgranicenja.Service1 objOgranicenja = new WSOgranicenja.Service1();
            int MaxBrojOperatera = objOgranicenja.DajMaxBrojOperatera(RegBrLeteliceWS);

            // ################################################################
            // 4. UPOREDJIVANJE TRENUTNOG BROJA I MAX BROJA OPERATERA
            if (UkupnoOperatera < MaxBrojOperatera)
            {
                imaMesta = true;
            }
            else
            {
                imaMesta = false;
            }


            return imaMesta;
        }

    }
}
