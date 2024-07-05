using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using DBUtils;
using System.Configuration;
using System.Data;

namespace KorisnickiInterfejs
{
    public partial class ZvanjeTabelarni : System.Web.UI.Page
    {
              
        
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakZvanja.DataSource = ds.Tables[0];
            gvSpisakZvanja.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsZvanjeDB objZvanjeDB = new KlasePodataka.clsZvanjeDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(objZvanjeDB.DajZvanjaPoNazivu(txbFilter.Text)); 
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsZvanjeDB objZvanjeDB = new KlasePodataka.clsZvanjeDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(objZvanjeDB.DajSvaZvanja()); 
        }
    }
}