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
    public partial class LetelicaTabelarni : System.Web.UI.Page
    {
              
        
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakLetelica.DataSource = ds.Tables[0];
            gvSpisakLetelica.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsLetelicaDB objLetelicaDB = new KlasePodataka.clsLetelicaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(objLetelicaDB.DajLetelicuPoNazivu(txbFilter.Text)); 
        }

        protected void btnSvi_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsLetelicaDB objLetelicaDB = new KlasePodataka.clsLetelicaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            NapuniGrid(objLetelicaDB.DajSveLetelice()); 
        }
    }
}