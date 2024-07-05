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
    public partial class LetelicaStampa : System.Web.UI.Page
    {
        // atributi

        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakLetelica.DataSource = ds.Tables[0];
            gvSpisakLetelica.DataBind();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            clsFormaLetelicaStampa objFormaLetelicaStampa = new clsFormaLetelicaStampa(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);

            string filter = string.Empty;

            try
            {
                if (Request.QueryString["filter"] != null)
                {
                    filter = Request.QueryString["filter"];
                }
            }
            catch (Exception ex)
            {
                filter = string.Empty;
            }

            if (string.IsNullOrEmpty(filter))
            {
                lblNaslov.Text = "SPISAK SVIH LETELICA";
            }
            else
            {
                lblNaslov.Text = "FILTRIRANI SPISAK LETELICA, naziv : " + filter;
            }

            NapuniGrid(objFormaLetelicaStampa.DajPodatkeZaGrid(filter));
        }

    }
}