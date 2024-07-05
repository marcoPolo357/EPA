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
    public partial class ZvanjeStampa : System.Web.UI.Page
    {
        // atributi

        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakZvanja.DataSource = ds.Tables[0];
            gvSpisakZvanja.DataBind();
        }
        
                
        protected void Page_Load(object sender, EventArgs e)
        {
            clsFormaZvanjeStampa objFormaZvanjeStampa = new clsFormaZvanjeStampa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
            string filter = Request.QueryString["filter"].ToString();

            if (filter.Equals(""))
            {
                lblNaslov.Text = "SPISAK SVIH ZVANJA"; 
            }
            else
            {
                lblNaslov.Text = "FILTRIRANI SPISAK ZVANJA, naziv=" + filter; 
            }

            NapuniGrid(objFormaZvanjeStampa.DajPodatkeZaGrid(filter)); 
        }
    }
}