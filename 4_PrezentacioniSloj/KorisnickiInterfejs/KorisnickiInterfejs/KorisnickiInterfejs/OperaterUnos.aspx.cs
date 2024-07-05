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
    public partial class OperaterUnos : System.Web.UI.Page
    {
        // atributi
        clsFormaOperaterUnos objFormaOperaterUnos; 
        
        // konstruktor


        // nase metode
        private void NapuniCombo()
        {
            // IZDVAJANJE PODATAKA IZ XML POSREDSTVOM WEB SERVISA
            DataSet dsLetelice = new DataSet();
            dsLetelice=objFormaOperaterUnos.DajPodatkeZaCombo();

            int ukupno = dsLetelice.Tables[0].Rows.Count;

            // PUNJENJE COMBO PODACIMA IZ DATASETA
            ddlLetelica.Items.Add("Izaberite...");
            for (int i = 0; i < ukupno; i++)
            {
                ddlLetelica.Items.Add(dsLetelice.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }

        private void IsprazniKontrole()
        {
            txbJMBG.Text = "";
            txbPrezime.Text = "";
            txbIme.Text = "";
            ddlLetelica.Text ="Izaberite...";
            lblStatus.Text = ""; 
        }



              


       


        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaOperaterUnos = new clsFormaOperaterUnos(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            if (!IsPostBack)
            {
                NapuniCombo();
            }
        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            // ***********preuzimanje vrednosti sa korisnickog interfejsa
            // 2. nacin - preuzimaju atributi klase prezentacione logike
            objFormaOperaterUnos.JMBG = txbJMBG.Text;
            objFormaOperaterUnos.Prezime = txbPrezime.Text;
            objFormaOperaterUnos.Ime = txbIme.Text;
            objFormaOperaterUnos.NazivLetelice = ddlLetelica.Text;  
            
            // *********** provera ispravnosti vrednosti
            // 1. provera popunjenosti
            bool SvePopunjeno = objFormaOperaterUnos.DaLiJeSvePopunjeno();

            // 2. provera ispravnosti - karakteri, vrednost iz domena, jedinstvenost zapisa
            bool JedinstvenZapis = objFormaOperaterUnos.DaLiJeJedinstvenZapis();


            // 3. provera ispravnosti - provera uskladjenosti podataka sa poslovnim pravilima
            bool UskladjenoSaPoslovnimPravilima = objFormaOperaterUnos.DaLiSuPodaciUskladjeniSaPoslovnimPravilima();

            // ********** snimanje u bazu podataka
            string porukaStatusaSnimanja = "";
            if (SvePopunjeno)
            {
                if (JedinstvenZapis)
                {
                    if (UskladjenoSaPoslovnimPravilima)
                    {
                        // snimanje podataka
                        objFormaOperaterUnos.SnimiPodatke();
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
                    porukaStatusaSnimanja = "VEC POSTOJI OPERATER SA ISTIM JMBG!";
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