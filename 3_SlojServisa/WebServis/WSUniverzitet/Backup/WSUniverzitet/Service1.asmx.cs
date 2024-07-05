using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//
using System.Data;

namespace WSUniverzitet
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet DajSvaZvanja()
        {
            DataSet dsZvanja = new DataSet();
            dsZvanja.ReadXml(Server.MapPath("~/") + "XML/Zvanja.XML");

            return dsZvanja;
        }


        [WebMethod]
        public string DajZvanje(string ID)
        {
            string NazivZvanja = "";
            DataSet dsZvanja = new DataSet();
            dsZvanja.ReadXml(Server.MapPath("~/") + "XML/Zvanja.XML");
            // filtriranje dataset-a
            DataRow[] result = dsZvanja.Tables[0].Select("Sifra='" + ID + "'");
            NazivZvanja = result[0].ItemArray[1].ToString();

            return NazivZvanja;
        }

        [WebMethod]
        public string DajIDZvanja(string naziv)
        {
            string IDZvanja = "";
            DataSet dsZvanja = new DataSet();
            dsZvanja.ReadXml(Server.MapPath("~/") + "XML/Zvanja.XML");
            // filtriranje dataset-a
            DataRow[] result = dsZvanja.Tables[0].Select("Naziv='" + naziv + "'");
            IDZvanja = result[0].ItemArray[0].ToString();

            return IDZvanja;
        }

    }
}