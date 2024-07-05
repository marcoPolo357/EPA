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
    public partial class LetelicaDetaljiEdit : System.Web.UI.Page
    {
        // atributi
        private string pRegBrLetelice = "";
        clsFormaLetelicaDetaljiEdit objFormaLetelicaDetaljiEdit; 

        // nase metode
        private void IsprazniKontrole()
        {
            txbRegBrLetelice.Text = "";
            txbNaziv.Text = ""; 

        }

        private void AktivirajKontrole()
        {
            txbRegBrLetelice.Enabled = true;
            txbNaziv.Enabled = true;
        }

        private void DeaktivirajKontrole()
        {
            txbRegBrLetelice.Enabled = false ;
            txbNaziv.Enabled = false;
        }

        private void PrikaziPodatke(clsFormaLetelicaDetaljiEdit objFormaLetelicaDetaljiEdit)
        {
            // podacima stranice upravlja klasa prezentacione logike, zato se uzimaju iz nje za prikaz
            txbRegBrLetelice.Text = objFormaLetelicaDetaljiEdit.RegBrPreuzeteLetelice;
            txbNaziv.Text = objFormaLetelicaDetaljiEdit.NazivPreuzeteLetelice; 

        }

        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaLetelicaDetaljiEdit = new clsFormaLetelicaDetaljiEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            pRegBrLetelice = Request.QueryString["RegBr"].ToString();
            objFormaLetelicaDetaljiEdit.RegBrPreuzeteLetelice = pRegBrLetelice;
            // OVDE SE NE DOBIJA NAZIV SPOLJA, VEC SE IZRACUNAVA NAZIV na set svojstvu property za sifru UNUTAR KLASE  
            if (!IsPostBack)
            {
                PrikaziPodatke(objFormaLetelicaDetaljiEdit);
            }  
        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            objFormaLetelicaDetaljiEdit.RegBrPreuzeteLetelice = txbRegBrLetelice.Text;
            bool uspehBrisanja = objFormaLetelicaDetaljiEdit.ObrisiLetelicu();
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
            //objFormaLetelicaDetaljiEdit.SifraPreuzetogZvanja = txbSifra.Text;
            // - ovo se izracuna iz sifre, pa se ne moze ni dodeliti: objFormaLetelicaDetaljiEdit.NazivPreuzetogZvanja = txbNaziv.Text; 
            AktivirajKontrole();
            txbRegBrLetelice.Focus();
 
        }

        protected void btnSnimiIzmenu_Click(object sender, EventArgs e)
        {
            objFormaLetelicaDetaljiEdit.RegBrIzmenjeneLetelice = txbRegBrLetelice.Text;
            objFormaLetelicaDetaljiEdit.NazivIzmenjeneLetelice = txbNaziv.Text;
            bool uspehIzmene =objFormaLetelicaDetaljiEdit.IzmeniLetelicu();
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