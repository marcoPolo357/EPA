using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using DBUtils;
using System.Configuration; 

namespace KorisnickiInterfejs
{
    public partial class LetelicaUnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsLetelicaDB objLetelicaDB = new KlasePodataka.clsLetelicaDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            KlasePodataka.clsLetelica objLetelica = new KlasePodataka.clsLetelica();
            objLetelica.Naziv = txbNaziv.Text;
            objLetelica.RegBr = txbRegBrLetelice.Text;
            objLetelicaDB.SnimiNovuLetelicu(objLetelica);
            lblStatus.Text = "Snimljeno";
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {

        }
    }
}