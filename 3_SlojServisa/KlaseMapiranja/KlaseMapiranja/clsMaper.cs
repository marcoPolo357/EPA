using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace KlaseMapiranja
{
    public class clsMaper
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public clsMaper(string NoviStringKonekcije)
        {
            pStringKonekcije = NoviStringKonekcije;
        }


        public string DajRegBrLeteliceZaWebServis(string RegBrLeteliceIzBazePodataka)
        {
            string RegBrLeteliceWS = "";
            clsLetelicaDB objZvanjeDB = new clsLetelicaDB(pStringKonekcije);
            string nazivLeteliceIzBazePodataka = objZvanjeDB.DajNazivPremaRegBr(RegBrLeteliceIzBazePodataka);

            // Reg Br Letelice za web servis je prvo slovo naziva Letelice,
            // "H" - heavy, odnosno teška letelica poput Airbus A380, C130 Globemaster, itd. -> U našem sistemu se beleži kao H - C130 Globemaster
            // "M" - medium, odnosno srednja letelica poput Boeing 737, Airbus A320, itd.
            // "L" - light, odnosno laka letelica poput Cessna 172, Cirrus SR22, itd.
            RegBrLeteliceWS = nazivLeteliceIzBazePodataka[0].ToString();

            return RegBrLeteliceWS;

        }

    }
}
