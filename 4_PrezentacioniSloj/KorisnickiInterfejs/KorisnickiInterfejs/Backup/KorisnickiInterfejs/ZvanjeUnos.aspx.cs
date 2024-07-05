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
    public partial class ZvanjeUnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSnimi_Click(object sender, EventArgs e)
        {
            KlasePodataka.clsZvanjeDB objZvanjeDB = new KlasePodataka.clsZvanjeDB(ConfigurationManager.ConnectionStrings["NasaKonekcija"].ToString());
            KlasePodataka.clsZvanje objZvanje = new KlasePodataka.clsZvanje();
            objZvanje.Naziv = txbNaziv.Text;
            objZvanje.Sifra = txbSifra.Text;
            objZvanjeDB.SnimiNovoZvanje(objZvanje);
            lblStatus.Text = "Snimljeno";
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {

        }
    }
}