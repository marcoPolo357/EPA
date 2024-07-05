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
    public partial class LetelicaTabelaEdit : System.Web.UI.Page
    {
        
        // nase metode
        private void NapuniGrid(DataSet ds)
        {
            // povezivanje grida sa datasetom
            gvSpisakLetelicaEdit.DataSource = ds.Tables[0];
            gvSpisakLetelicaEdit.DataBind();
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clsFormaLetelicaTabelaEdit objFormaLetelicaTabelaEdit = new clsFormaLetelicaTabelaEdit(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString);
                NapuniGrid(objFormaLetelicaTabelaEdit.DajPodatkeZaGrid(""));
            }
        }

        protected void gvSpisakZvanjaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("LetelicaDetaljiEdit.aspx?RegBr=" + gvSpisakLetelicaEdit.Rows[gvSpisakLetelicaEdit.SelectedIndex].Cells[1].Text); 
        }

       
    }
}