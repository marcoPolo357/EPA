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
    public partial class OperaterSpisak : System.Web.UI.Page
    {
        // atributi
        private clsFormaOperaterSpisak objFormaOperaterSpisak;

        // konstruktor


        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvOperateri.DataSource = ds.Tables[0];
            gvOperateri.DataBind();
        }

      
         
        // dogadjaji
        protected void Page_Load(object sender, EventArgs e)
        {
            objFormaOperaterSpisak = new clsFormaOperaterSpisak(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);  
        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            NapuniGrid(objFormaOperaterSpisak.DajPodatkeZaGrid(txbFilter.Text));   
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            NapuniGrid(objFormaOperaterSpisak.DajPodatkeZaGrid(""));   
        }
    }
}