using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using System.Configuration;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class NastavnikUnos : System.Web.UI.Page
    {
        // atributi
        clsFormaNastavnikUnos objFormaNastavnikUnos; 
        
        // konstruktor


        // nase metode
        private void NapuniCombo()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet dsZvanja = new DataSet();
            dsZvanja=objFormaNastavnikUnos.DajPodatkeZaCombo();

            int ukupno = dsZvanja.Tables[0].Rows.Count;

            // PUNJENJE COMBO PODACIMA IZ DATASETA
            ddlZvanje.Items.Add("Izaberite...");
            for (int i = 0; i < ukupno; i++)
            {
                ddlZvanje.Items.Add(dsZvanja.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }

        private void IsprazniKontrole()
        {
            txbJMBG.Text = "";
            txbPrezime.Text = "";
            txbIme.Text = "";
            ddlZvanje.Text ="Izaberite...";
            lblStatus.Text = ""; 
        }



              


       


        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaNastavnikUnos = new clsFormaNastavnikUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            if (!IsPostBack)
            {
                NapuniCombo();
            }
        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            // ***********preuzimanje vrednosti sa korisnickog interfejsa
            // 2. nacin - preuzimaju atributi klase prezentacione logike
            objFormaNastavnikUnos.JMBG = txbJMBG.Text;
            objFormaNastavnikUnos.Prezime = txbPrezime.Text;
            objFormaNastavnikUnos.Ime = txbIme.Text;
            objFormaNastavnikUnos.NazivZvanja = ddlZvanje.Text;  
            
            // *********** provera ispravnosti vrednosti
            // 1. provera popunjenosti
            bool SvePopunjeno = objFormaNastavnikUnos.DaLiJeSvePopunjeno();

            // 2. provera ispravnosti - karakteri, vrednost iz domena, jedinstvenost zapisa
            bool JedinstvenZapis = objFormaNastavnikUnos.DaLiJeJedinstvenZapis();


            // 3. provera ispravnosti - provera uskladjenosti podataka sa poslovnim pravilima
            bool UskladjenoSaPoslovnimPravilima = objFormaNastavnikUnos.DaLiSuPodaciUskladjeniSaPoslovnimPravilima();

            // ********** snimanje u bazu podataka
            string porukaStatusaSnimanja = "";
            if (SvePopunjeno)
            {
                if (JedinstvenZapis)
                {
                    if (UskladjenoSaPoslovnimPravilima)
                    {
                        // snimanje podataka
                        objFormaNastavnikUnos.SnimiPodatke();
                        // priprema teksta poruke o uspehu snimanja
                        porukaStatusaSnimanja = "USPESNO SNIMLJENI PODACI!";
                    }
                    else
                    {
                        porukaStatusaSnimanja = "PODACI NISU U SKLADU SA POSLOVNIM PRAVILIMA!";
                    }
                }
                else
                {
                    porukaStatusaSnimanja = "VEC POSTOJI NASTAVNIK SA ISTIM JMBG!";
                }
            }
            else
            { 
                // priprema teksta poruke o gresci
                porukaStatusaSnimanja = "NISU SVI PODACI POPUNJENI!";
                txbJMBG.Focus();  
            }


            // ********** obavestavanje korisnika o statusu snimanja
            lblStatus.Text = porukaStatusaSnimanja; 


        }

        protected void btnPonisti_Click(object sender, EventArgs e)
        {
            IsprazniKontrole();
        }
    }
}