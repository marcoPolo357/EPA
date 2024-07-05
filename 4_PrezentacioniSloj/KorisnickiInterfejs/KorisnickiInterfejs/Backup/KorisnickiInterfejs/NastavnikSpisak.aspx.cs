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
    public partial class NastavnikSpisak : System.Web.UI.Page
    {
        // atributi
        private clsFormaNastavnikSpisak objFormaNastavnikSpisak;

        // konstruktor


        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvNastavnici.DataSource = ds.Tables[0];
            gvNastavnici.DataBind();
        }

      
         
        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaNastavnikSpisak = new clsFormaNastavnikSpisak(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);  
        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            NapuniGrid(objFormaNastavnikSpisak.DajPodatkeZaGrid(txbFilter.Text));   
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            NapuniGrid(objFormaNastavnikSpisak.DajPodatkeZaGrid(""));   
        }
    }
}