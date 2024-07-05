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
    public partial class ZvanjeTabelaEdit : System.Web.UI.Page
    {
        
        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakZvanjaEdit.DataSource = ds.Tables[0];
            gvSpisakZvanjaEdit.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsFormaZvanjeTabelaEdit objFormaZvanjeTabelaEdit = new clsFormaZvanjeTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                NapuniGrid(objFormaZvanjeTabelaEdit.DajPodatkeZaGrid(""));
            }
        }

        protected void gvSpisakZvanjaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ZvanjeDetaljiEdit.aspx?Sifra=" + gvSpisakZvanjaEdit.Rows[gvSpisakZvanjaEdit.SelectedIndex].Cells[1].Text); 
        }

       
    }
}