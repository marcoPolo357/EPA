using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;
using PrezentacionaLogika;
using System.Configuration; 

namespace KorisnickiInterfejs
{
    public partial class ZvanjeDetaljiEdit : System.Web.UI.Page
    {
        // atributi
        private string pSifra = "";
        clsFormaZvanjeDetaljiEdit objFormaZvanjeDetaljiEdit; 

        // nase metode
        private void IsprazniKontrole()
        {
            txbSifra.Text = "";
            txbNaziv.Text = ""; 

        }

        private void AktivirajKontrole()
        {
            txbSifra.Enabled = true;
            txbNaziv.Enabled = true;
        }

        private void DeaktivirajKontrole()
        {
            txbSifra.Enabled = false ;
            txbNaziv.Enabled = false;
        }

        private void PrikaziPodatke(clsFormaZvanjeDetaljiEdit objFormaZvanjeDetaljiEdit)
        {
            // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
            txbSifra.Text = objFormaZvanjeDetaljiEdit.SifraPreuzetogZvanja;
            txbNaziv.Text = objFormaZvanjeDetaljiEdit.NazivPreuzetogZvanja; 

        }

        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaZvanjeDetaljiEdit = new clsFormaZvanjeDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            pSifra = Request.QueryString["Sifra"].ToString();
            objFormaZvanjeDetaljiEdit.SifraPreuzetogZvanja = pSifra;
            // OVDE SE NE DOBIJA NAZIV SPOLJA, VEC SE IZRACUNAVA NAZIV na set svojstvu property za sifru UNUTAR KLASE  
            if (!IsPostBack)
            {
                PrikaziPodatke(objFormaZvanjeDetaljiEdit);
            }  
        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            objFormaZvanjeDetaljiEdit.SifraPreuzetogZvanja = txbSifra.Text;
            bool uspehBrisanja = objFormaZvanjeDetaljiEdit.ObrisiZvanje();
            if (uspehBrisanja)
            {
                lblStatus.Text = "Uspesno obrisan zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
        }

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            // PREUZIMANJE POCETNIH, STARIH VREDNOSTI - OVDE NEMA POTREBE JER SE URADI NA PAGE LOAD
            //objFormaZvanjeDetaljiEdit.SifraPreuzetogZvanja = txbSifra.Text;
            // - ovo se izracuna iz sifre, pa se ne moze ni dodeliti: objFormaZvanjeDetaljiEdit.NazivPreuzetogZvanja = txbNaziv.Text; 
            AktivirajKontrole();
            txbSifra.Focus();
 
        }

        protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
        {
            objFormaZvanjeDetaljiEdit.SifraIzmenjenogZvanja = txbSifra.Text;
            objFormaZvanjeDetaljiEdit.NazivIzmenjenogZvanja = txbNaziv.Text;
            bool uspehIzmene =objFormaZvanjeDetaljiEdit.IzmeniZvanje();
            if (uspehIzmene)
            {
                lblStatus.Text = "Uspesno izmenjen zapis!";
                IsprazniKontrole();
            }
            else
            {
                lblStatus.Text = "NEUSPEH BRISANJA zapisa!";
            }
            DeaktivirajKontrole();
        }
    }
}